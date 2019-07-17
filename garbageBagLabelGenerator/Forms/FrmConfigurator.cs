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
            numericUpDown2.Minimum = 1;
            numericUpDown3.Minimum = 1;
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

        void drawPage()
        {

            int width = Int32.Parse(textBox5.Text);
            int height = Int32.Parse(textBox4.Text);
            int columns = (int)numericUpDown2.Value;
            int rows = (int)numericUpDown3.Value;

            int marginLeft = (int)numericUpDown6.Value;
            int marginTop = (int)numericUpDown4.Value;

            Image img = new Bitmap(pictureBox3.Width, pictureBox3.Height);
            Graphics g = Graphics.FromImage(img);
            Pen p = new Pen(Color.Black, 2);
            Rectangle rectangle = new Rectangle(0, 0, width, height);
            Brush brush = new SolidBrush(Color.White);
            g.FillRectangle(brush, rectangle);
            g.DrawRectangle(p, rectangle);

            int labelWidth = Int32.Parse(textBox1.Text);
            int labelHeight = Int32.Parse(textBox2.Text);

            //draw label
            int currentColumn = 0;
            int currentRow = 0;

            Pen labelBorder = new Pen(Color.White, 0);

            while (currentRow < rows)
            {
                Point labelLocation = new Point();
                //labelLocation = new Point(Label.Size.Width * currentColumn, Label.Size.Height * currentRow);
                labelLocation.X = labelWidth * currentColumn + marginLeft - 5;
                labelLocation.Y = labelWidth * currentRow + marginTop;
                Rectangle label = new Rectangle(labelLocation, new Size(labelWidth,labelHeight));
                int labelCenter = labelLocation.X + width / 2;
                g.DrawRectangle(labelBorder, label);

                currentColumn++;
                if (currentColumn % columns == 0)
                {
                    currentColumn = 0;
                    currentRow++;
                }
            }

            pictureBox3.Image = img;
            pictureBox1.SizeMode=PictureBoxSizeMode.Normal;
            pictureBox3.Update();
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            drawPage();
        }
    }
}
