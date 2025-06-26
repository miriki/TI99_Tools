using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TI99_Tools

{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Scan_Click(object sender, EventArgs e)
        {
            string directoryPath = txt_Files_Directory.Text;
            if (    Directory.Exists(directoryPath))
            {
                string[] chrFiles = Directory.GetFiles(directoryPath, "*.*", SearchOption.TopDirectoryOnly);
                lst_Filenames.Items.Clear();
                foreach (string file in chrFiles)
                {
                    lst_Filenames.Items.Add(Path.GetFileName(file));
                }
            }
            else
            {
                MessageBox.Show("Directory doesn't exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Bitmap CreateBitmapFromData(List<byte[]> data)
        {
            int width = 1024;
            int height = 512;
            Bitmap bmp = new Bitmap(width, height);
            Color background = Color.Black;
            Color grid = Color.FromArgb(63, 63, 63);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(background);
                using (Pen gridPen = new Pen(grid))
                {
                    for (int x = 0; x <= width; x += 32)
                    {
                        g.DrawLine(gridPen, x, 0, x, height - 1);
                    }
                    for (int y = 0; y <= height; y += 32)
                    {
                        g.DrawLine(gridPen, 0, y, width - 1, y);
                    }
                }
            }
            return bmp;
        }

        public static Bitmap DrawGlyphsOnBitmap(Bitmap bmp, List<byte[]> data, int char1, int charCount, int bytesPerChar)
        {
            Color glyphColor = Color.White;

            if (data.Count == charCount)
            {
                for (int i = 0; i < charCount; i++)
                {
                    int charIndex = char1 + i;
                    byte[] glyph = data[i];
                    int row = charIndex / 32;
                    int col = charIndex % 32;
                    int baseX = col * 32;
                    int baseY = row * 32;
                    for (int y = 0; y < bytesPerChar; y++)
                    {
                        byte line = glyph[y];
                        for (int bit = 0; bit < 8; bit++)
                        {
                            if ((line & (1 << (7 - bit))) != 0)
                            {
                                int pixelX = baseX + bit * 4;
                                int pixelY = baseY + y * 4;
                                for (int dx = 0; dx < 4; dx++)
                                {
                                    for (int dy = 0; dy < 4; dy++)
                                    {
                                        int px = pixelX + dx;
                                        int py = pixelY + dy;
                                        if (px < bmp.Width && py < bmp.Height)
                                            bmp.SetPixel(px, py, glyphColor);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return bmp;
        }

        public static List<byte[]> ParseDataLines(IEnumerable<string> lines)
        {
            var dataLines = new List<byte[]>();

            string pattern = @"^\s+DATA\s+>([0-9A-Fa-f]{4}),\s*>([0-9A-Fa-f]{4}),\s*>([0-9A-Fa-f]{4}),\s*>([0-9A-Fa-f]{4})";
            foreach (var line in lines)
            {
                var match = Regex.Match(line, pattern, RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    byte[] bytes = new byte[8];
                    for (int i = 1; i <= 4; i++)
                    {
                        ushort value = Convert.ToUInt16(match.Groups[i].Value, 16);
                        bytes[(i - 1) * 2] = (byte)(value >> 8);     // High Byte
                        bytes[(i - 1) * 2 + 1] = (byte)(value & 0xFF);   // Low Byte
                    }
                    dataLines.Add(bytes);
                }
            }
            return dataLines;
        }

        private void lst_Filenames_SelectedIndexChanged(object sender, EventArgs e)
        {
            int char1=32;
            int charCount=96;
            int bytesPerChar=8;
            int filler=255;

            if (lst_Filenames.SelectedItem != null)
            {
                string selectedFile = Path.Combine(txt_Files_Directory.Text, lst_Filenames.SelectedItem.ToString());
                if (File.Exists(selectedFile))
                {
                    string[] lines = File.ReadAllLines(selectedFile);
                    var filteredLines = lines.Where(line => !line.TrimStart().StartsWith("*") && !string.IsNullOrWhiteSpace(line)).ToList();
                    string fil_header = filteredLines.FirstOrDefault(line => !Regex.IsMatch(line, @"^\s"));
                    string pattern1 = @"^([A-Za-z][A-Za-z0-9_]{0,5})\s+BYTE\s+>([0-9A-Fa-f]{2}),>([0-9A-Fa-f]{2}),>([0-9A-Fa-f]{2}),>([0-9A-Fa-f]{2})";
                    var match1 = Regex.Match(fil_header, pattern1, RegexOptions.IgnoreCase);
                    if (match1.Success)
                    {
                        string fontString = match1.Groups[1].Value;  // z. B. "FONT23"
                        char1 = Convert.ToInt32(match1.Groups[2].Value, 16);
                        charCount = Convert.ToInt32(match1.Groups[3].Value, 16);
                        bytesPerChar = Convert.ToInt32(match1.Groups[4].Value, 16);
                        lbl_Font_Info.Text = $"Font: '{fontString}' for >{match1.Groups[3].Value} ({charCount}) characters starting at >{match1.Groups[2].Value} ({char1}) with >{match1.Groups[4].Value} ({bytesPerChar}) bytes per character";
                        filler = Convert.ToInt32(match1.Groups[5].Value, 16);
                        Debug.WriteLine("Header: " + fil_header);
                        Debug.WriteLine($"Font name  : {fontString}");
                        Debug.WriteLine($"1st char      : >{match1.Groups[2].Value} ({char1})");
                        Debug.WriteLine($"Char count : >{match1.Groups[3].Value} ({charCount})");
                        Debug.WriteLine($"Char len   : >{match1.Groups[4].Value} ({bytesPerChar})");
                        List<byte[]> fil_data = ParseDataLines(filteredLines);
                        // foreach (var b in fil_data)
                        // {
                        // Debug.WriteLine(BitConverter.ToString(b));
                        // }
                        pictureBox1.Image = DrawGlyphsOnBitmap(CreateBitmapFromData(fil_data), fil_data, char1, charCount, bytesPerChar);
                    }
                    else
                    {
                        Console.WriteLine("Header couldn't be found or decoded");
                    }
                }
                else
                {
                    MessageBox.Show("File doesn't exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}

