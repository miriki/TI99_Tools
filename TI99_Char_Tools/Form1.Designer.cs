namespace TI99_Char_Tools
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            pictureBox1 = new PictureBox();
            lbl_Font_Info = new Label();
            btn_View = new Button();
            btn_Scan = new Button();
            label1 = new Label();
            txt_Files_Directory = new TextBox();
            lst_Filenames = new ListBox();
            tabPage2 = new TabPage();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1240, 612);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(pictureBox1);
            tabPage1.Controls.Add(lbl_Font_Info);
            tabPage1.Controls.Add(btn_View);
            tabPage1.Controls.Add(btn_Scan);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(txt_Files_Directory);
            tabPage1.Controls.Add(lst_Filenames);
            tabPage1.Location = new Point(4, 27);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1232, 581);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "View";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(204, 64);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1024, 512);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // lbl_Font_Info
            // 
            lbl_Font_Info.Location = new Point(204, 38);
            lbl_Font_Info.Name = "lbl_Font_Info";
            lbl_Font_Info.Size = new Size(768, 23);
            lbl_Font_Info.TabIndex = 5;
            lbl_Font_Info.Text = "Font: \"xxxxxx\" for >xx (xx) characters starting at >xx (xx) with >xx (xx) bytes per character";
            lbl_Font_Info.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btn_View
            // 
            btn_View.Location = new Point(87, 36);
            btn_View.Name = "btn_View";
            btn_View.Size = new Size(75, 26);
            btn_View.TabIndex = 4;
            btn_View.Text = "view";
            btn_View.UseVisualStyleBackColor = true;
            // 
            // btn_Scan
            // 
            btn_Scan.Location = new Point(6, 36);
            btn_Scan.Name = "btn_Scan";
            btn_Scan.Size = new Size(75, 26);
            btn_Scan.TabIndex = 3;
            btn_Scan.Text = "scan";
            btn_Scan.UseVisualStyleBackColor = true;
            btn_Scan.Click += btn_Scan_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 9);
            label1.Name = "label1";
            label1.Size = new Size(78, 18);
            label1.TabIndex = 1;
            label1.Text = "files in dir:";
            // 
            // txt_Files_Directory
            // 
            txt_Files_Directory.Location = new Point(90, 6);
            txt_Files_Directory.Name = "txt_Files_Directory";
            txt_Files_Directory.Size = new Size(1138, 26);
            txt_Files_Directory.TabIndex = 0;
            txt_Files_Directory.Text = "c:\\Users\\mritt\\Downloads\\Emulators\\TI99MAME\\Dev - Assembler\\Fonts\\";
            // 
            // lst_Filenames
            // 
            lst_Filenames.FormattingEnabled = true;
            lst_Filenames.ItemHeight = 18;
            lst_Filenames.Location = new Point(6, 68);
            lst_Filenames.Name = "lst_Filenames";
            lst_Filenames.Size = new Size(192, 508);
            lst_Filenames.TabIndex = 7;
            lst_Filenames.SelectedIndexChanged += lst_Filenames_SelectedIndexChanged;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1232, 584);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1263, 636);
            Controls.Add(tabControl1);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TextBox txt_Files_Directory;
        private TabPage tabPage2;
        private Label label1;
        private Button btn_Scan;
        private Button btn_View;
        private Label lbl_Font_Info;
        private PictureBox pictureBox1;
        private ListBox lst_Filenames;
    }
}
