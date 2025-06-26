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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            btn_Analyze = new Button();
            groupBox4 = new GroupBox();
            rbt_720k = new RadioButton();
            rbt_360k = new RadioButton();
            rbt_180k = new RadioButton();
            rbt_90k = new RadioButton();
            lst_Image_Analyze = new ListBox();
            groupBox3 = new GroupBox();
            rbt_T80 = new RadioButton();
            rbt_T40 = new RadioButton();
            groupBox2 = new GroupBox();
            rbt_QD = new RadioButton();
            rbt_DD = new RadioButton();
            rbt_SD = new RadioButton();
            groupBox1 = new GroupBox();
            rbt_DS = new RadioButton();
            rbt_SS = new RadioButton();
            tabPage2 = new TabPage();
            btn_Directory = new Button();
            lst_Image_Directory = new ListBox();
            lst_Image_Files = new ListBox();
            label1 = new Label();
            txt_Files_Directory = new TextBox();
            btn_Scan = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(355, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(826, 612);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btn_Analyze);
            tabPage1.Controls.Add(groupBox4);
            tabPage1.Controls.Add(lst_Image_Analyze);
            tabPage1.Controls.Add(groupBox3);
            tabPage1.Controls.Add(groupBox2);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Location = new Point(4, 27);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(818, 581);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Analyze";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_Analyze
            // 
            btn_Analyze.Location = new Point(716, 6);
            btn_Analyze.Name = "btn_Analyze";
            btn_Analyze.Size = new Size(96, 26);
            btn_Analyze.TabIndex = 8;
            btn_Analyze.Text = "Analyze";
            btn_Analyze.UseVisualStyleBackColor = true;
            btn_Analyze.Click += btn_Analyze_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(rbt_720k);
            groupBox4.Controls.Add(rbt_360k);
            groupBox4.Controls.Add(rbt_180k);
            groupBox4.Controls.Add(rbt_90k);
            groupBox4.Location = new Point(287, 6);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(126, 80);
            groupBox4.TabIndex = 5;
            groupBox4.TabStop = false;
            groupBox4.Text = "cap K";
            // 
            // rbt_720k
            // 
            rbt_720k.AutoSize = true;
            rbt_720k.Location = new Point(65, 53);
            rbt_720k.Name = "rbt_720k";
            rbt_720k.Size = new Size(53, 22);
            rbt_720k.TabIndex = 3;
            rbt_720k.TabStop = true;
            rbt_720k.Text = "720";
            rbt_720k.UseVisualStyleBackColor = true;
            // 
            // rbt_360k
            // 
            rbt_360k.AutoSize = true;
            rbt_360k.Location = new Point(65, 24);
            rbt_360k.Name = "rbt_360k";
            rbt_360k.Size = new Size(53, 22);
            rbt_360k.TabIndex = 2;
            rbt_360k.TabStop = true;
            rbt_360k.Text = "360";
            rbt_360k.UseVisualStyleBackColor = true;
            // 
            // rbt_180k
            // 
            rbt_180k.AutoSize = true;
            rbt_180k.Location = new Point(6, 53);
            rbt_180k.Name = "rbt_180k";
            rbt_180k.Size = new Size(53, 22);
            rbt_180k.TabIndex = 1;
            rbt_180k.TabStop = true;
            rbt_180k.Text = "180";
            rbt_180k.UseVisualStyleBackColor = true;
            // 
            // rbt_90k
            // 
            rbt_90k.AutoSize = true;
            rbt_90k.Location = new Point(6, 25);
            rbt_90k.Name = "rbt_90k";
            rbt_90k.Size = new Size(44, 22);
            rbt_90k.TabIndex = 0;
            rbt_90k.TabStop = true;
            rbt_90k.Text = "90";
            rbt_90k.UseVisualStyleBackColor = true;
            // 
            // lst_Image_Analyze
            // 
            lst_Image_Analyze.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lst_Image_Analyze.FormattingEnabled = true;
            lst_Image_Analyze.ItemHeight = 19;
            lst_Image_Analyze.Location = new Point(9, 96);
            lst_Image_Analyze.Name = "lst_Image_Analyze";
            lst_Image_Analyze.Size = new Size(803, 479);
            lst_Image_Analyze.TabIndex = 7;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(rbt_T80);
            groupBox3.Controls.Add(rbt_T40);
            groupBox3.Location = new Point(210, 6);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(71, 80);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "tracks";
            // 
            // rbt_T80
            // 
            rbt_T80.AutoSize = true;
            rbt_T80.Location = new Point(6, 53);
            rbt_T80.Name = "rbt_T80";
            rbt_T80.Size = new Size(44, 22);
            rbt_T80.TabIndex = 1;
            rbt_T80.TabStop = true;
            rbt_T80.Text = "80";
            rbt_T80.UseVisualStyleBackColor = true;
            // 
            // rbt_T40
            // 
            rbt_T40.AutoSize = true;
            rbt_T40.Location = new Point(6, 25);
            rbt_T40.Name = "rbt_T40";
            rbt_T40.Size = new Size(44, 22);
            rbt_T40.TabIndex = 0;
            rbt_T40.TabStop = true;
            rbt_T40.Text = "40";
            rbt_T40.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rbt_QD);
            groupBox2.Controls.Add(rbt_DD);
            groupBox2.Controls.Add(rbt_SD);
            groupBox2.Location = new Point(83, 6);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(121, 80);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "dens";
            // 
            // rbt_QD
            // 
            rbt_QD.AutoSize = true;
            rbt_QD.Location = new Point(61, 24);
            rbt_QD.Name = "rbt_QD";
            rbt_QD.Size = new Size(50, 22);
            rbt_QD.TabIndex = 2;
            rbt_QD.TabStop = true;
            rbt_QD.Text = "QD";
            rbt_QD.UseVisualStyleBackColor = true;
            // 
            // rbt_DD
            // 
            rbt_DD.AutoSize = true;
            rbt_DD.Location = new Point(6, 53);
            rbt_DD.Name = "rbt_DD";
            rbt_DD.Size = new Size(50, 22);
            rbt_DD.TabIndex = 1;
            rbt_DD.TabStop = true;
            rbt_DD.Text = "DD";
            rbt_DD.UseVisualStyleBackColor = true;
            // 
            // rbt_SD
            // 
            rbt_SD.AutoSize = true;
            rbt_SD.Location = new Point(6, 25);
            rbt_SD.Name = "rbt_SD";
            rbt_SD.Size = new Size(49, 22);
            rbt_SD.TabIndex = 0;
            rbt_SD.TabStop = true;
            rbt_SD.Text = "SD";
            rbt_SD.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbt_DS);
            groupBox1.Controls.Add(rbt_SS);
            groupBox1.Location = new Point(6, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(71, 80);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "sides";
            // 
            // rbt_DS
            // 
            rbt_DS.AutoSize = true;
            rbt_DS.Location = new Point(6, 53);
            rbt_DS.Name = "rbt_DS";
            rbt_DS.Size = new Size(49, 22);
            rbt_DS.TabIndex = 1;
            rbt_DS.TabStop = true;
            rbt_DS.Text = "DS";
            rbt_DS.UseVisualStyleBackColor = true;
            // 
            // rbt_SS
            // 
            rbt_SS.AutoSize = true;
            rbt_SS.Location = new Point(6, 25);
            rbt_SS.Name = "rbt_SS";
            rbt_SS.Size = new Size(48, 22);
            rbt_SS.TabIndex = 0;
            rbt_SS.TabStop = true;
            rbt_SS.Text = "SS";
            rbt_SS.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btn_Directory);
            tabPage2.Controls.Add(lst_Image_Directory);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(818, 584);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Directory";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_Directory
            // 
            btn_Directory.Location = new Point(716, 6);
            btn_Directory.Name = "btn_Directory";
            btn_Directory.Size = new Size(96, 23);
            btn_Directory.TabIndex = 9;
            btn_Directory.Text = "Directory";
            btn_Directory.UseVisualStyleBackColor = true;
            btn_Directory.Click += btn_Directory_Click;
            // 
            // lst_Image_Directory
            // 
            lst_Image_Directory.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lst_Image_Directory.FormattingEnabled = true;
            lst_Image_Directory.ItemHeight = 19;
            lst_Image_Directory.Location = new Point(6, 39);
            lst_Image_Directory.Name = "lst_Image_Directory";
            lst_Image_Directory.Size = new Size(807, 536);
            lst_Image_Directory.TabIndex = 8;
            // 
            // lst_Image_Files
            // 
            lst_Image_Files.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lst_Image_Files.FormattingEnabled = true;
            lst_Image_Files.ItemHeight = 19;
            lst_Image_Files.Location = new Point(12, 69);
            lst_Image_Files.Name = "lst_Image_Files";
            lst_Image_Files.SelectionMode = SelectionMode.MultiExtended;
            lst_Image_Files.Size = new Size(337, 555);
            lst_Image_Files.TabIndex = 7;
            lst_Image_Files.MouseDoubleClick += lst_Image_Files_MouseDoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 12);
            label1.Name = "label1";
            label1.Size = new Size(254, 18);
            label1.TabIndex = 8;
            label1.Text = "check disk images files in directory:";
            // 
            // txt_Files_Directory
            // 
            txt_Files_Directory.Location = new Point(14, 33);
            txt_Files_Directory.Name = "txt_Files_Directory";
            txt_Files_Directory.Size = new Size(335, 26);
            txt_Files_Directory.TabIndex = 9;
            txt_Files_Directory.Text = "c:\\Users\\mritt\\AppData\\Roaming\\TI99MAME\\ti99_dsk\\check\\";
            // 
            // btn_Scan
            // 
            btn_Scan.Location = new Point(274, 8);
            btn_Scan.Name = "btn_Scan";
            btn_Scan.Size = new Size(75, 26);
            btn_Scan.TabIndex = 10;
            btn_Scan.Text = "scan";
            btn_Scan.UseVisualStyleBackColor = true;
            btn_Scan.Click += btn_Scan_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 636);
            Controls.Add(btn_Scan);
            Controls.Add(txt_Files_Directory);
            Controls.Add(label1);
            Controls.Add(lst_Image_Files);
            Controls.Add(tabControl1);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Form1";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabPage2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

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
