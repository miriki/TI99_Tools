using static System.Windows.Forms.LinkLabel;
using System.Text.RegularExpressions;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TI99_Char_Tools
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_Scan_Click(object sender, EventArgs e)
        {
            string directoryPath = txt_Files_Directory.Text;
            if (Directory.Exists(directoryPath))
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
                MessageBox.Show("Das Verzeichnis existiert nicht!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Bitmap CreateBitmapFromData(List<byte[]> data)
        {
            int width = 1024;
            int height = 512;
            Bitmap bmp = new Bitmap(width, height);

            Color background = Color.Black;
            Color grid = Color.FromArgb(63, 63, 63); // Dein gewähltes Grauton

            using (Graphics g = Graphics.FromImage(bmp))
            {
                // Hintergrund komplett füllen
                g.Clear(background);

                using (Pen gridPen = new Pen(grid))
                {
                    // Vertikale Linien bei x = 0, 32, 64, ..., 768
                    for (int x = 0; x <= width; x += 32)
                    {
                        g.DrawLine(gridPen, x, 0, x, height - 1);
                    }

                    // Horizontale Linien bei y = 0, 32, 64, ..., 512
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

                    // Position im Raster (32 Spalten)
                    int row = charIndex / 32;
                    int col = charIndex % 32;
                    int baseX = col * 32;
                    int baseY = row * 32;

                    // Jedes Byte = 1 Zeile, jedes Bit = 4x4 Pixelblock
                    for (int y = 0; y < bytesPerChar; y++)
                    {
                        byte line = glyph[y];
                        for (int bit = 0; bit < 8; bit++)
                        {
                            if ((line & (1 << (7 - bit))) != 0)
                            {
                                int pixelX = baseX + bit * 4;
                                int pixelY = baseY + y * 4;

                                // 4x4 Pixel setzen
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

            // Regex-Muster für Zeilen im Format: DATA >XXXX,>XXXX,>XXXX,>XXXX
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
            // string fil_header;
            // string[] fil_data;
            int char1=32;
            int charCount=96;
            int bytesPerChar=8;
            int filler=255;
            if (lst_Filenames.SelectedItem != null)
            {
                string selectedFile = Path.Combine(txt_Files_Directory.Text, lst_Filenames.SelectedItem.ToString());
                if (File.Exists(selectedFile))
                {

                    string[] lines = File.ReadAllLines(selectedFile).ToArray();

                    // Ignoriere Zeilen, die mit '*' beginnen
                    var filteredLines = lines.Where(line => !line.TrimStart().StartsWith("*")).ToList();

                    // Finde die erste nicht eingerückte Zeile (kein Leerzeichen am Anfang)
                    string fil_header = filteredLines.FirstOrDefault(line => !Regex.IsMatch(line, @"^\s"));

                    //string pattern1 = @"^(FONT\d+)\s+BYTE\s+>([0-9A-Fa-f]{2}),>([0-9A-Fa-f]{2}),>([0-9A-Fa-f]{2}),>([0-9A-Fa-f]{2})";
                    string pattern1 = @"^([A-Za-z][A-Za-z0-9]{0,5})\s+BYTE\s+>([0-9A-Fa-f]{2}),>([0-9A-Fa-f]{2}),>([0-9A-Fa-f]{2}),>([0-9A-Fa-f]{2})";

                    var match1 = Regex.Match(fil_header, pattern1, RegexOptions.IgnoreCase);
                    if (match1.Success)
                    {
                        string fontString = match1.Groups[1].Value;  // z. B. "FONT23"
                        char1 = Convert.ToInt32(match1.Groups[2].Value, 16);
                        charCount = Convert.ToInt32(match1.Groups[3].Value, 16);
                        bytesPerChar = Convert.ToInt32(match1.Groups[4].Value, 16);
                        filler = Convert.ToInt32(match1.Groups[5].Value, 16);

                        Debug.WriteLine("Header: " + fil_header);
                        Debug.WriteLine($"Fontzeichenfolge : {fontString}");
                        Debug.WriteLine($"Char1             : >{match1.Groups[2].Value} ({char1})");
                        Debug.WriteLine($"CharCount         : >{match1.Groups[3].Value} ({charCount})");
                        Debug.WriteLine($"Bytes pro Zeichen : >{match1.Groups[4].Value} ({bytesPerChar})");
                        // Debug.WriteLine($"Filler            : >{match1.Groups[5].Value} ({filler})");
                    }
                    else
                    {
                        Console.WriteLine("Header-Zeile konnte nicht analysiert werden.");
                    }

                    List<byte[]> fil_data = ParseDataLines(filteredLines);
                    foreach (var b in fil_data)
                    {
                        Debug.WriteLine(BitConverter.ToString(b));
                    }

                    pictureBox1.Image = DrawGlyphsOnBitmap(CreateBitmapFromData(fil_data), fil_data, char1, charCount, bytesPerChar);

                }
                else
                {
                    MessageBox.Show("Die ausgewählte Datei existiert nicht!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}

