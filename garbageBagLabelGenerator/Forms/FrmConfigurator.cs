using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace garbageBagLabelGenerator.Forms
{
    public partial class FrmConfigurator : Form
    {
        public FrmConfigurator()
        {
            InitializeComponent();
            startup();
        }

        void startup()
        {
            getFonts();
        }

        void getFonts()
        {
            List<string> fonts = new List<string>();

            foreach (FontFamily font in FontFamily.Families)
            {
                fonts.Add(font.Name);
            }

            comboBox2.DataSource = fonts;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            button3.BackColor = colorDialog1.Color;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
        }

        void drawLabel()
        {
            
            int width = Int32.Parse(textBox1.Text);
            int height = Int32.Parse(textBox2.Text);

            int multiplier = pictureBox1.Width / width;
            width = width * multiplier;
            height = height * multiplier;

            Image img = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(img);
            Pen p = new Pen(Color.Black, 2);
            Rectangle rectangle = new Rectangle(0,0, width, height);
            Brush brush = new SolidBrush(Color.White);
            g.FillRectangle(brush, rectangle);
            g.DrawRectangle(p, rectangle);

            Brush fontBrush = new SolidBrush(Color.Black);
            string s = textBox3.Text;
            string fontName = comboBox2.SelectedText;
            int fontSize = (int)numericUpDown1.Value;
            Font font = new Font(fontName, fontSize);
            PointF pointF = new PointF(0, 0);
            g.DrawString(s, font, fontBrush, pointF);

            pictureBox1.Image = img;
            pictureBox1.Update();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            drawLabel();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            drawLabel();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            drawLabel();
        }
    }
}
