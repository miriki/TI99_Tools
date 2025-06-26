using System.Drawing;
using System.Windows.Forms;
// using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace TI99_Tools
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_Analyze = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbt_720k = new System.Windows.Forms.RadioButton();
            this.rbt_360k = new System.Windows.Forms.RadioButton();
            this.rbt_180k = new System.Windows.Forms.RadioButton();
            this.rbt_90k = new System.Windows.Forms.RadioButton();
            this.lst_Image_Analyze = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbt_T80 = new System.Windows.Forms.RadioButton();
            this.rbt_T40 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbt_QD = new System.Windows.Forms.RadioButton();
            this.rbt_DD = new System.Windows.Forms.RadioButton();
            this.rbt_SD = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbt_DS = new System.Windows.Forms.RadioButton();
            this.rbt_SS = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_Directory = new System.Windows.Forms.Button();
            this.lst_Image_Directory = new System.Windows.Forms.ListBox();
            this.lst_Image_Files = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Files_Directory = new System.Windows.Forms.TextBox();
            this.btn_Scan = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(355, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(826, 612);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn_Analyze);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.lst_Image_Analyze);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(818, 581);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Analyze";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_Analyze
            // 
            this.btn_Analyze.Location = new System.Drawing.Point(716, 6);
            this.btn_Analyze.Name = "btn_Analyze";
            this.btn_Analyze.Size = new System.Drawing.Size(96, 26);
            this.btn_Analyze.TabIndex = 8;
            this.btn_Analyze.Text = "Analyze";
            this.btn_Analyze.UseVisualStyleBackColor = true;
            this.btn_Analyze.Click += new System.EventHandler(this.btn_Analyze_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbt_720k);
            this.groupBox4.Controls.Add(this.rbt_360k);
            this.groupBox4.Controls.Add(this.rbt_180k);
            this.groupBox4.Controls.Add(this.rbt_90k);
            this.groupBox4.Location = new System.Drawing.Point(287, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(126, 80);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "cap K";
            // 
            // rbt_720k
            // 
            this.rbt_720k.AutoSize = true;
            this.rbt_720k.Location = new System.Drawing.Point(65, 53);
            this.rbt_720k.Name = "rbt_720k";
            this.rbt_720k.Size = new System.Drawing.Size(53, 22);
            this.rbt_720k.TabIndex = 3;
            this.rbt_720k.TabStop = true;
            this.rbt_720k.Text = "720";
            this.rbt_720k.UseVisualStyleBackColor = true;
            // 
            // rbt_360k
            // 
            this.rbt_360k.AutoSize = true;
            this.rbt_360k.Location = new System.Drawing.Point(65, 24);
            this.rbt_360k.Name = "rbt_360k";
            this.rbt_360k.Size = new System.Drawing.Size(53, 22);
            this.rbt_360k.TabIndex = 2;
            this.rbt_360k.TabStop = true;
            this.rbt_360k.Text = "360";
            this.rbt_360k.UseVisualStyleBackColor = true;
            // 
            // rbt_180k
            // 
            this.rbt_180k.AutoSize = true;
            this.rbt_180k.Location = new System.Drawing.Point(6, 53);
            this.rbt_180k.Name = "rbt_180k";
            this.rbt_180k.Size = new System.Drawing.Size(53, 22);
            this.rbt_180k.TabIndex = 1;
            this.rbt_180k.TabStop = true;
            this.rbt_180k.Text = "180";
            this.rbt_180k.UseVisualStyleBackColor = true;
            // 
            // rbt_90k
            // 
            this.rbt_90k.AutoSize = true;
            this.rbt_90k.Location = new System.Drawing.Point(6, 25);
            this.rbt_90k.Name = "rbt_90k";
            this.rbt_90k.Size = new System.Drawing.Size(44, 22);
            this.rbt_90k.TabIndex = 0;
            this.rbt_90k.TabStop = true;
            this.rbt_90k.Text = "90";
            this.rbt_90k.UseVisualStyleBackColor = true;
            // 
            // lst_Image_Analyze
            // 
            this.lst_Image_Analyze.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_Image_Analyze.FormattingEnabled = true;
            this.lst_Image_Analyze.ItemHeight = 19;
            this.lst_Image_Analyze.Location = new System.Drawing.Point(9, 96);
            this.lst_Image_Analyze.Name = "lst_Image_Analyze";
            this.lst_Image_Analyze.Size = new System.Drawing.Size(803, 479);
            this.lst_Image_Analyze.TabIndex = 7;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbt_T80);
            this.groupBox3.Controls.Add(this.rbt_T40);
            this.groupBox3.Location = new System.Drawing.Point(210, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(71, 80);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "tracks";
            // 
            // rbt_T80
            // 
            this.rbt_T80.AutoSize = true;
            this.rbt_T80.Location = new System.Drawing.Point(6, 53);
            this.rbt_T80.Name = "rbt_T80";
            this.rbt_T80.Size = new System.Drawing.Size(44, 22);
            this.rbt_T80.TabIndex = 1;
            this.rbt_T80.Text = "80";
            this.rbt_T80.UseVisualStyleBackColor = true;
            // 
            // rbt_T40
            // 
            this.rbt_T40.AutoSize = true;
            this.rbt_T40.Checked = true;
            this.rbt_T40.Location = new System.Drawing.Point(6, 25);
            this.rbt_T40.Name = "rbt_T40";
            this.rbt_T40.Size = new System.Drawing.Size(44, 22);
            this.rbt_T40.TabIndex = 0;
            this.rbt_T40.TabStop = true;
            this.rbt_T40.Text = "40";
            this.rbt_T40.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbt_QD);
            this.groupBox2.Controls.Add(this.rbt_DD);
            this.groupBox2.Controls.Add(this.rbt_SD);
            this.groupBox2.Location = new System.Drawing.Point(83, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(121, 80);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "dens";
            // 
            // rbt_QD
            // 
            this.rbt_QD.AutoSize = true;
            this.rbt_QD.Location = new System.Drawing.Point(61, 24);
            this.rbt_QD.Name = "rbt_QD";
            this.rbt_QD.Size = new System.Drawing.Size(50, 22);
            this.rbt_QD.TabIndex = 2;
            this.rbt_QD.Text = "QD";
            this.rbt_QD.UseVisualStyleBackColor = true;
            // 
            // rbt_DD
            // 
            this.rbt_DD.AutoSize = true;
            this.rbt_DD.Checked = true;
            this.rbt_DD.Location = new System.Drawing.Point(6, 53);
            this.rbt_DD.Name = "rbt_DD";
            this.rbt_DD.Size = new System.Drawing.Size(50, 22);
            this.rbt_DD.TabIndex = 1;
            this.rbt_DD.TabStop = true;
            this.rbt_DD.Text = "DD";
            this.rbt_DD.UseVisualStyleBackColor = true;
            // 
            // rbt_SD
            // 
            this.rbt_SD.AutoSize = true;
            this.rbt_SD.Location = new System.Drawing.Point(6, 25);
            this.rbt_SD.Name = "rbt_SD";
            this.rbt_SD.Size = new System.Drawing.Size(49, 22);
            this.rbt_SD.TabIndex = 0;
            this.rbt_SD.Text = "SD";
            this.rbt_SD.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbt_DS);
            this.groupBox1.Controls.Add(this.rbt_SS);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(71, 80);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "sides";
            // 
            // rbt_DS
            // 
            this.rbt_DS.AutoSize = true;
            this.rbt_DS.Checked = true;
            this.rbt_DS.Location = new System.Drawing.Point(6, 53);
            this.rbt_DS.Name = "rbt_DS";
            this.rbt_DS.Size = new System.Drawing.Size(49, 22);
            this.rbt_DS.TabIndex = 1;
            this.rbt_DS.TabStop = true;
            this.rbt_DS.Text = "DS";
            this.rbt_DS.UseVisualStyleBackColor = true;
            // 
            // rbt_SS
            // 
            this.rbt_SS.AutoSize = true;
            this.rbt_SS.Location = new System.Drawing.Point(6, 25);
            this.rbt_SS.Name = "rbt_SS";
            this.rbt_SS.Size = new System.Drawing.Size(48, 22);
            this.rbt_SS.TabIndex = 0;
            this.rbt_SS.Text = "SS";
            this.rbt_SS.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_Directory);
            this.tabPage2.Controls.Add(this.lst_Image_Directory);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(818, 581);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Directory";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_Directory
            // 
            this.btn_Directory.Location = new System.Drawing.Point(716, 6);
            this.btn_Directory.Name = "btn_Directory";
            this.btn_Directory.Size = new System.Drawing.Size(96, 23);
            this.btn_Directory.TabIndex = 9;
            this.btn_Directory.Text = "Directory";
            this.btn_Directory.UseVisualStyleBackColor = true;
            this.btn_Directory.Click += new System.EventHandler(this.btn_Directory_Click);
            // 
            // lst_Image_Directory
            // 
            this.lst_Image_Directory.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_Image_Directory.FormattingEnabled = true;
            this.lst_Image_Directory.ItemHeight = 19;
            this.lst_Image_Directory.Location = new System.Drawing.Point(6, 39);
            this.lst_Image_Directory.Name = "lst_Image_Directory";
            this.lst_Image_Directory.Size = new System.Drawing.Size(807, 536);
            this.lst_Image_Directory.TabIndex = 8;
            // 
            // lst_Image_Files
            // 
            this.lst_Image_Files.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_Image_Files.FormattingEnabled = true;
            this.lst_Image_Files.ItemHeight = 19;
            this.lst_Image_Files.Location = new System.Drawing.Point(12, 69);
            this.lst_Image_Files.Name = "lst_Image_Files";
            this.lst_Image_Files.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lst_Image_Files.Size = new System.Drawing.Size(337, 555);
            this.lst_Image_Files.TabIndex = 7;
            this.lst_Image_Files.SelectedIndexChanged += new System.EventHandler(this.lst_Image_Files_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "check disk images files in directory:";
            // 
            // txt_Files_Directory
            // 
            this.txt_Files_Directory.Location = new System.Drawing.Point(14, 33);
            this.txt_Files_Directory.Name = "txt_Files_Directory";
            this.txt_Files_Directory.Size = new System.Drawing.Size(335, 26);
            this.txt_Files_Directory.TabIndex = 9;
            this.txt_Files_Directory.Text = "c:\\Users\\mritt\\AppData\\Roaming\\TI99MAME\\ti99_dsk\\check\\";
            // 
            // btn_Scan
            // 
            this.btn_Scan.Location = new System.Drawing.Point(274, 8);
            this.btn_Scan.Name = "btn_Scan";
            this.btn_Scan.Size = new System.Drawing.Size(75, 26);
            this.btn_Scan.TabIndex = 10;
            this.btn_Scan.Text = "scan";
            this.btn_Scan.UseVisualStyleBackColor = true;
            this.btn_Scan.Click += new System.EventHandler(this.btn_Scan_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 636);
            this.Controls.Add(this.btn_Scan);
            this.Controls.Add(this.txt_Files_Directory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lst_Image_Files);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private GroupBox groupBox3;
        private RadioButton rbt_T80;
        private RadioButton rbt_T40;
        private GroupBox groupBox2;
        private RadioButton rbt_DD;
        private RadioButton rbt_SD;
        private GroupBox groupBox1;
        private RadioButton rbt_DS;
        private RadioButton rbt_SS;
        private TabPage tabPage2;
        private ListBox lst_Image_Analyze;
        private RadioButton rbt_QD;
        private GroupBox groupBox4;
        private RadioButton rbt_720k;
        private RadioButton rbt_360k;
        private RadioButton rbt_180k;
        private RadioButton rbt_90k;
        private ListBox lst_Image_Files;
        private Label label1;
        private TextBox txt_Files_Directory;
        private Button btn_Scan;
        private ListBox lst_Image_Directory;
        private Button btn_Analyze;
        private Button btn_Directory;

    }
}
