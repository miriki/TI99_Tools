using System.Drawing;
using System.Windows.Forms;

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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_Font_Info = new System.Windows.Forms.Label();
            this.btn_Scan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Files_Directory = new System.Windows.Forms.TextBox();
            this.lst_Filenames = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1240, 612);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.lbl_Font_Info);
            this.tabPage1.Controls.Add(this.btn_Scan);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txt_Files_Directory);
            this.tabPage1.Controls.Add(this.lst_Filenames);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1232, 581);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "View";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(204, 64);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1024, 512);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_Font_Info
            // 
            this.lbl_Font_Info.Location = new System.Drawing.Point(204, 38);
            this.lbl_Font_Info.Name = "lbl_Font_Info";
            this.lbl_Font_Info.Size = new System.Drawing.Size(768, 23);
            this.lbl_Font_Info.TabIndex = 5;
            this.lbl_Font_Info.Text = "Font: \"xxxxxx\" for >xx (xx) characters starting at >xx (xx) with >xx (xx) bytes p" +
    "er character";
            this.lbl_Font_Info.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Scan
            // 
            this.btn_Scan.Location = new System.Drawing.Point(6, 36);
            this.btn_Scan.Name = "btn_Scan";
            this.btn_Scan.Size = new System.Drawing.Size(75, 26);
            this.btn_Scan.TabIndex = 3;
            this.btn_Scan.Text = "scan";
            this.btn_Scan.UseVisualStyleBackColor = true;
            this.btn_Scan.Click += new System.EventHandler(this.btn_Scan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "files in dir:";
            // 
            // txt_Files_Directory
            // 
            this.txt_Files_Directory.Location = new System.Drawing.Point(90, 6);
            this.txt_Files_Directory.Name = "txt_Files_Directory";
            this.txt_Files_Directory.Size = new System.Drawing.Size(1138, 26);
            this.txt_Files_Directory.TabIndex = 0;
            this.txt_Files_Directory.Text = "c:\\Users\\mritt\\Downloads\\Emulators\\TI99MAME\\Dev - Assembler\\Fonts\\";
            // 
            // lst_Filenames
            // 
            this.lst_Filenames.FormattingEnabled = true;
            this.lst_Filenames.ItemHeight = 18;
            this.lst_Filenames.Location = new System.Drawing.Point(6, 68);
            this.lst_Filenames.Name = "lst_Filenames";
            this.lst_Filenames.Size = new System.Drawing.Size(192, 508);
            this.lst_Filenames.TabIndex = 7;
            this.lst_Filenames.SelectedIndexChanged += new System.EventHandler(this.lst_Filenames_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 636);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TextBox txt_Files_Directory;
        private Label label1;
        private Button btn_Scan;
        private Label lbl_Font_Info;
        private PictureBox pictureBox1;
        private ListBox lst_Filenames;
    }
}

