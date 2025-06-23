using System;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TI99_Disk_Tools
{
    public partial class Form1 : Form
    {

        const int dsk_img_size = 737280;

        const int dsk_pvib = 0;
        const int dsk_vib_size = 256;
        const int dsk_pabm = 56;
        const int dsk_abm_size = 200;

        const int dsk_pfdi = 1;
        const int dsk_fdi_size = 256;

        const int fil_fdr_size = 256;
        const int fil_pdcp = 28;
        const int fil_dcp_size = 228;

        public Form1()
        {
            InitializeComponent();
        }

        private DateTime decode_fil_datetime(byte[] m_abyTime)
        {
            DateTime result;
            int nYear = 0;
            int nMonth = 0;
            int nDay = 0;
            int nHour = 0;
            int nMinute = 0;
            int nSec = 0;

            result = new DateTime(0);

            int nFirst = (int)((m_abyTime[0] << 8) & 0xff00) + (int)(m_abyTime[1] & 0xff);
            int nSecond = (int)((m_abyTime[2] << 8) & 0xff00) + (int)(m_abyTime[3] & 0xff);

            if (nFirst == 0 && nSecond == 0)
            {
                result = new DateTime(0);
            }
            else
            {
                nYear = (nSecond >> 9) & 0x7f;
                nMonth = (nSecond >> 5) & 0x0f;
                nDay = nSecond & 0x1f;
                nHour = (nFirst >> 11) & 0x1f;
                nMinute = (nFirst >> 5) & 0x3f;
                nSec = (nFirst & 0x1f) * 2;
                if (nYear < 70)
                {
                    nYear = nYear + 2000;
                }
                else
                {
                    nYear = nYear + 1900;
                }
                result = new DateTime(nYear, nMonth, nDay, nHour, nMinute, nSec);
            }

            return result;
        }

        private void btn_Scan_Click(object sender, EventArgs e)
        {
            string directoryPath = txt_Files_Directory.Text;
            if (Directory.Exists(directoryPath))
            {
                string[] dskFiles = Directory.GetFiles(directoryPath, "*.DSK", SearchOption.TopDirectoryOnly);
                lst_Image_Files.Items.Clear();
                foreach (string file in dskFiles)
                {
                    lst_Image_Files.Items.Add(Path.GetFileName(file));
                }
            }
            else
            {
                MessageBox.Show("Das Verzeichnis existiert nicht!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private byte[] Dsk_Get_Image(string img_dpf)
        {

            byte[] dsk_img = new byte[dsk_img_size];

            if (File.Exists(img_dpf))
            {
                try
                {
                    byte[] fileData = File.ReadAllBytes(img_dpf);
                    if (fileData.Length <= dsk_img_size)
                    {
                        Array.Copy(fileData, 0, dsk_img, 0, fileData.Length);
                        for (int i = fileData.Length; i < dsk_img_size; i++)
                        {
                            dsk_img[i] = 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //
                }
            }

            return dsk_img;
        }

        private byte[] Dsk_Get_VIB(byte[] dsk_img)
        {
            byte[] dsk_vib = new byte[dsk_vib_size];
            Array.Copy(dsk_img, dsk_pvib * 256, dsk_vib, 0, dsk_vib_size);
            return dsk_vib;
        }

        private byte[] Dsk_Get_ABM(byte[] dsk_vib)
        {
            byte[] dsk_abm = new byte[dsk_abm_size];
            Array.Copy(dsk_vib, dsk_pabm, dsk_abm, 0, dsk_abm_size);
            return dsk_abm;
        }

        private byte[] Dsk_Get_FDI(byte[] dsk_img)
        {
            byte[] dsk_fdi = new byte[dsk_fdi_size];
            Array.Copy(dsk_img, dsk_pfdi * 256, dsk_fdi, 0, dsk_fdi_size);
            return dsk_fdi;
        }

        private byte[] Dsk_Get_FDR(byte[] dsk_img, int fil_pfdr)
        {
            byte[] fil_fdr = new byte[fil_fdr_size];
            Array.Copy(dsk_img, fil_pfdr * 256, fil_fdr, 0, fil_fdr_size);
            return fil_fdr;
        }

        private byte[] Dsk_Get_DCP(byte[] dsk_fdr)
        {
            byte[] fil_dcp = new byte[fil_dcp_size];
            Array.Copy(dsk_fdr, fil_pdcp, fil_dcp, 0, fil_dcp_size);
            return fil_dcp;
        }

        private void Dsk_Analyze()
        {

            string img_f;

            byte[] dsk_img;

            // Sector 0: Volume Information Block (VIB)
            byte[] dsk_vib = new byte[dsk_vib_size];

            string dsk_name;
            int dsk_sct;
            int dsk_sct_per_trk;
            string dsk_idt;
            int dsk_trk_per_sid;
            int dsk_sid;
            int dsk_dns;
            string dsk_dir1_name;
            int dsk_dir1_pfdi;
            string dsk_dir2_name;
            int dsk_dir2_pfdi;
            string dsk_dir3_name;
            int dsk_dir3_pfdi;

            byte[] dsk_abm = new byte[dsk_abm_size];
            string dsk_abm_str;

            int dsk_cls;
            int dsk_cap;

            // Sector 1: File Descriptor Index Record (FDI)
            byte[] dsk_fdi = new byte[dsk_fdi_size];

            int fdri;
            int fil_pfdr;

            // Sector xxxx: File Descriptor Record (FDR) - Pointer in FDI to this
            byte[] fil_fdr = new byte[fil_fdr_size];

            string fil_name;
            int fil_xrl;
            int fil_sta;
            string fil_sta_str;
            int fil_nrs;
            int fil_sct;
            int fil_eof;
            int fil_rln;
            int fil_lv3;
            DateTime fil_crd;
            DateTime fil_upd;

            byte[] fil_dcp = new byte[fil_dcp_size];

            if (lst_Image_Files.SelectedItems.Count > 0)
            {
                lst_Image_Directory.Items.Clear();
                foreach (var item in lst_Image_Files.SelectedItems)
                {
                    img_f = item.ToString();

                    lst_Image_Analyze.Items.Add(img_f);

                    string img_dpf = Path.Combine(txt_Files_Directory.Text, img_f);

                    dsk_img = Dsk_Get_Image(img_dpf);

                    // ========== disk header ==============================

                    // Array.Copy(dsk_img, dsk_pvib*256, dsk_vib, 0, dsk_vib_size);
                    dsk_vib = Dsk_Get_VIB(dsk_img);

                    dsk_name = Encoding.ASCII.GetString(dsk_vib, 0, 10);
                    lst_Image_Analyze.Items.Add($"Name: '{dsk_name}'");

                    dsk_sct = dsk_vib[10] * 256 + dsk_vib[11];
                    lst_Image_Analyze.Items.Add($"Sectors: {dsk_sct}");

                    dsk_sct_per_trk = dsk_vib[12];
                    lst_Image_Analyze.Items.Add($"Sectors per Track: {dsk_sct_per_trk}");

                    dsk_idt = Encoding.ASCII.GetString(dsk_vib, 13, 3);
                    lst_Image_Analyze.Items.Add($"Identity: {dsk_idt}");

                    dsk_trk_per_sid = dsk_vib[17];
                    lst_Image_Analyze.Items.Add($"Tracks per Side: {dsk_trk_per_sid}");
                    if (dsk_trk_per_sid == 40) { rbt_T40.Checked = true; }
                    if (dsk_trk_per_sid == 80) { rbt_T80.Checked = true; }

                    dsk_sid = dsk_vib[18];
                    lst_Image_Analyze.Items.Add($"Sides: {dsk_sid}");
                    if (dsk_sid == 1) { rbt_SS.Checked = true; }
                    if (dsk_sid == 2) { rbt_DS.Checked = true; }

                    dsk_dns = dsk_vib[19];
                    lst_Image_Analyze.Items.Add($"Density: {dsk_dns}");
                    if (dsk_dns == 0) { rbt_SD.Checked = true; }
                    if (dsk_dns == 1) { rbt_SD.Checked = true; }
                    if (dsk_dns == 2) { rbt_DD.Checked = true; }
                    if (dsk_dns == 3) { rbt_QD.Checked = true; }

                    dsk_cls = 1;
                    if (dsk_trk_per_sid * dsk_sid * dsk_sct_per_trk > 2000) { dsk_cls = 2; }

                    lst_Image_Analyze.Items.Add($"Clustersize: {dsk_cls}");

                    dsk_cap = dsk_sct * 256 / 1024;
                    lst_Image_Analyze.Items.Add($"Capacity {dsk_cap}K {(dsk_sid == 1 ? "SS" : "DS")} {((dsk_dns < 2) ? "SD" : (dsk_dns == 2 ? "DD" : "QD"))} {(dsk_trk_per_sid == 40 ? "40" : "80")}");
                    if (dsk_cap == 90) { rbt_90k.Checked = true; }
                    if (dsk_cap == 180) { rbt_180k.Checked = true; }
                    if (dsk_cap == 360) { rbt_360k.Checked = true; }
                    if (dsk_cap == 720) { rbt_720k.Checked = true; }

                    lst_Image_Analyze.Items.Add("");

                    dsk_dir1_name = Encoding.ASCII.GetString(dsk_vib, 20, 10);
                    lst_Image_Analyze.Items.Add($"Dir 1 Name: {dsk_dir1_name}");
                    dsk_dir1_pfdi = dsk_vib[30] * 256 + dsk_vib[31];
                    lst_Image_Analyze.Items.Add($"Dir 1 FDI: {dsk_dir1_pfdi}");

                    dsk_dir2_name = Encoding.ASCII.GetString(dsk_vib, 32, 10);
                    lst_Image_Analyze.Items.Add($"Dir 2 Name: {dsk_dir2_name}");
                    dsk_dir2_pfdi = dsk_vib[42] * 256 + dsk_vib[43];
                    lst_Image_Analyze.Items.Add($"Dir 2 FDI: {dsk_dir2_pfdi}");

                    dsk_dir3_name = Encoding.ASCII.GetString(dsk_vib, 44, 10);
                    lst_Image_Analyze.Items.Add($"Dir 3 Name: {dsk_dir3_name}");
                    dsk_dir3_pfdi = dsk_vib[54] * 256 + dsk_vib[55];
                    lst_Image_Analyze.Items.Add($"Dir 3 FDI: {dsk_dir3_pfdi}");

                    // Array.Copy(dsk_vib, 56, dsk_abm, 0, dsk_abm_size);
                    Dsk_Get_ABM(dsk_vib);

                    dsk_abm_str = "";
                    foreach (byte b in dsk_abm)
                    {
                        for (int i = 7; i >= 0; i--)
                        {
                            for (int j = 1; j <= dsk_cls; j++)
                            {
                                dsk_abm_str = dsk_abm_str + ((b & (1 << i)) != 0 ? "X" : ".");
                            }
                        }
                    }
                    dsk_abm_str = dsk_abm_str.Substring(0, dsk_sct);

                    lst_Image_Analyze.Items.Add("");

                    for (int i = 0; i < dsk_abm_str.Length; i += 80)
                    {
                        int length = Math.Min(80, dsk_abm_str.Length - i);
                        lst_Image_Analyze.Items.Add($"{i}: {dsk_abm_str.ToString().Substring(i, length)}");
                    }

                    // ========== file header ==============================

                    // Array.Copy(dsk_img, dsk_pfdi*256, dsk_fdi, 0, dsk_fdi_size);
                    dsk_fdi = Dsk_Get_FDI(dsk_img);

                    fdri = 0;
                    fil_pfdr = dsk_fdi[fdri] * 256 + dsk_fdi[fdri + 1];

                    while (fil_pfdr != 0)
                    {

                        lst_Image_Analyze.Items.Add("");
                        lst_Image_Analyze.Items.Add($"FDR Sct: {fil_pfdr}");

                        // Array.Copy(dsk_img, fil_pfdr * 256, fil_fdr, 0, fil_fdr_size);
                        fil_fdr = Dsk_Get_FDR(dsk_img, fil_pfdr);

                        fil_name = Encoding.ASCII.GetString(fil_fdr, 0, 10);
                        lst_Image_Analyze.Items.Add($"Name: '{fil_name}'");

                        fil_xrl = fil_fdr[10] * 256 + fil_fdr[11];
                        lst_Image_Analyze.Items.Add($"Ext. RecLen: {fil_xrl}");

                        fil_sta = fil_fdr[12];
                        lst_Image_Analyze.Items.Add($"Status: {fil_sta}");
                        fil_sta_str = "";
                        fil_sta_str = fil_sta_str + ((fil_sta & 1) != 0 ? "Program" : "Data file");
                        fil_sta_str = fil_sta_str + ((fil_sta & 2) != 0 ? ", Internal" : ", Display");
                        fil_sta_str = fil_sta_str + ((fil_sta & 8) != 0 ? ", Protected" : ", Unprotected");
                        fil_sta_str = fil_sta_str + ((fil_sta & 16) != 0 ? ", Backup Flag" : "");
                        fil_sta_str = fil_sta_str + ((fil_sta & 32) != 0 ? ", Emulate Flag" : "");
                        fil_sta_str = fil_sta_str + ((fil_sta & 128) != 0 ? ", Variable" : ", Fixed");
                        lst_Image_Analyze.Items.Add($"Status: {fil_sta_str}");

                        fil_nrs = fil_fdr[13];
                        lst_Image_Analyze.Items.Add($"Rec/Sct: {fil_nrs}");

                        fil_sct = fil_fdr[14] * 256 + fil_fdr[15];
                        lst_Image_Analyze.Items.Add($"Sectors: {fil_sct}");

                        fil_eof = fil_fdr[16];
                        lst_Image_Analyze.Items.Add($"EOF: {fil_eof}");

                        fil_rln = fil_fdr[17];
                        lst_Image_Analyze.Items.Add($"RecLen: {fil_rln}");

                        fil_lv3 = fil_fdr[18] + fil_fdr[19] * 256;
                        lst_Image_Analyze.Items.Add($"L3 Rec: {fil_lv3}");

                        byte[] dttm;
                        dttm = new byte[4];

                        Array.Copy(fil_fdr, 20, dttm, 0, 4);
                        fil_crd = decode_fil_datetime(dttm);
                        lst_Image_Analyze.Items.Add($"DT create: {fil_crd.ToString()}");

                        Array.Copy(fil_fdr, 24, dttm, 0, 4);
                        fil_upd = decode_fil_datetime(dttm);
                        lst_Image_Analyze.Items.Add($"DT update: {fil_upd.ToString()}");

                        // Array.Copy(dsk_fdi, 28, fil_dcp, 0, fil_dcp_size);
                        fil_dcp = Dsk_Get_DCP(fil_fdr);

                        // decode "Data Chain Pointer Blocks" information

                        // ...

                        fdri = fdri + 2;
                        fil_pfdr = dsk_fdi[fdri] * 256 + dsk_fdi[fdri + 1];

                    }
                    lst_Image_Analyze.Items.Add("");

                }
            }
        }

        private void Dsk_Directory()
        {

            string img_f;

            byte[] dsk_img;

            byte[] dsk_vib = new byte[dsk_vib_size];
            byte[] dsk_fdi = new byte[dsk_fdi_size];

            int fdri;
            int fil_pfdr;

            byte[] fil_fdr = new byte[fil_fdr_size];

            string dsk_name;
            int dsk_sct;
            int dsk_sct_used;
            int dsk_sct_free;

            string fil_name;
            int fil_xrl;
            int fil_sta;
            int fil_sct;
            int fil_rln;

            string fil_typ;
            string fil_pro;

            string cat_str;
            string cat_str1;
            string cat_str2;
            string cat_str3;
            string cat_str4;
            string cat_str5;

            if (lst_Image_Files.SelectedItems.Count > 0)
            {
                lst_Image_Directory.Items.Clear();
                foreach (var item in lst_Image_Files.SelectedItems)
                {
                    img_f = item.ToString();

                    string img_dpf = Path.Combine(txt_Files_Directory.Text, img_f);

                    dsk_img = Dsk_Get_Image(img_dpf);

                    dsk_vib = Dsk_Get_VIB(dsk_img);

                    dsk_name = Encoding.ASCII.GetString(dsk_vib, 0, 10);
                    dsk_sct = dsk_vib[10] * 256 + dsk_vib[11];

                    dsk_fdi = Dsk_Get_FDI(dsk_img);

                    dsk_sct_used = 2;
                    fdri = 0;
                    fil_pfdr = dsk_fdi[fdri] * 256 + dsk_fdi[fdri + 1];
                    while (fil_pfdr != 0)
                    {
                        fil_fdr = Dsk_Get_FDR(dsk_img, fil_pfdr);
                        fil_sct = fil_fdr[14] * 256 + fil_fdr[15];
                        dsk_sct_used = dsk_sct_used + fil_sct;
                        fdri = fdri + 2;
                        fil_pfdr = dsk_fdi[fdri] * 256 + dsk_fdi[fdri + 1];
                    }
                    dsk_sct_free = dsk_sct - dsk_sct_used;

                    cat_str1 = dsk_name;
                    while (cat_str1.Length < 10) { cat_str1 = cat_str1 + " "; }
                    cat_str2 = dsk_sct_free.ToString();
                    while (cat_str2.Length < 6) { cat_str2 = " " + cat_str2; }
                    cat_str2 = "F:" + cat_str2;
                    cat_str3 = dsk_sct_used.ToString();
                    while (cat_str3.Length < 6) { cat_str3 = " " + cat_str3; }
                    cat_str3 = "U:" + cat_str3;
                    cat_str = cat_str1 + " " + cat_str2 + " " + cat_str3;
                    lst_Image_Directory.Items.Add(cat_str);

                    cat_str = "Filename   Size Type       P";
                    lst_Image_Directory.Items.Add(cat_str);

                    cat_str = "---------- ---- ---------- -";
                    lst_Image_Directory.Items.Add(cat_str);

                    fdri = 0;
                    fil_pfdr = dsk_fdi[fdri] * 256 + dsk_fdi[fdri + 1];
                    while (fil_pfdr != 0)
                    {
                        fil_fdr = Dsk_Get_FDR(dsk_img, fil_pfdr);
                        fil_name = Encoding.ASCII.GetString(fil_fdr, 0, 10);
                        fil_xrl = fil_fdr[10] * 256 + fil_fdr[11];
                        fil_sta = fil_fdr[12];
                        fil_typ = ((fil_sta & 1) != 0 ? "Program" : "");
                        if (fil_typ == "")
                        {
                            fil_typ = fil_typ + ((fil_sta & 2) != 0 ? "Int" : "Dis");
                            fil_typ = fil_typ + ((fil_sta & 128) != 0 ? "/Var" : "/Fix");
                        }
                        fil_pro = ((fil_sta & 8) != 0 ? "P" : " ");
                        fil_sct = fil_fdr[14] * 256 + fil_fdr[15];
                        fil_rln = fil_fdr[17];
                        fdri = fdri + 2;
                        fil_pfdr = dsk_fdi[fdri] * 256 + dsk_fdi[fdri + 1];

                        cat_str1 = fil_name;
                        while (cat_str1.Length < 10) { cat_str1 = cat_str1 + " "; }
                        cat_str2 = fil_sct.ToString();
                        while (cat_str2.Length < 4) { cat_str2 = " " + cat_str2; }
                        cat_str3 = fil_typ;
                        while (cat_str3.Length < 7) { cat_str3 = cat_str3 + " "; }
                        if (fil_typ != "Program")
                        {
                            cat_str4 = fil_rln.ToString();
                            while (cat_str4.Length < 3) { cat_str4 = " " + cat_str4; }
                        }
                        else
                        {
                            cat_str4 = "   ";
                        }
                        cat_str5 = fil_pro;
                        while (cat_str5.Length < 1) { cat_str5 = cat_str5 + " "; }
                        cat_str = cat_str1 + " " + cat_str2 + " " + cat_str3 + cat_str4 + " " + cat_str5;
                        lst_Image_Directory.Items.Add(cat_str);

                    }

                    cat_str = "---------- ---- ---------- -";
                    lst_Image_Directory.Items.Add(cat_str);
                    lst_Image_Directory.Items.Add("");

                }
            }
        }

        private void lst_Image_Files_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void btn_Analyze_Click(object sender, EventArgs e)
        {
            Dsk_Analyze();
        }

        private void btn_Directory_Click(object sender, EventArgs e)
        {
            Dsk_Directory();
        }

    }
}
