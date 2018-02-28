using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace garbageBagLabelGenerator
{
    public class GarbageBagLabel
    {
        public string GarbageType { get; set; }
        public Company Company { get; set; }
        public string UnitName { get; set; }

        public GarbageBagLabel(string garbageType, Company company, string unitName)
        {
            GarbageType = garbageType;
            Company = company;
            UnitName = unitName;
        }

        public void print(System.Drawing.Printing.PrintPageEventArgs e, int labelCode)
        {
            Graphics g = e.Graphics;
            draw(g, labelCode);
        }

        void draw(Graphics g, int code)
        {
            g.PageUnit = GraphicsUnit.Millimeter;
            float lineSize = 0.2f;
            Pen p = new Pen(Color.Black, lineSize);
            Pen labelBorder = new Pen(Color.White, 0);

            //page settings
            int pageWidth = 210;
            int pageHeight = 297;
            //int marginTop = 4;
            //int marginLeft = 4;

            //font settings
            Font fontDefault = new Font("Times New Roman", 8);
            Font fontSmall = new Font("Times New Roman", 6);
            Font fontBold = new Font("Times New Roman", 8, FontStyle.Bold);
            Brush brush = Brushes.Black;
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;

            //label settings
            int labelWidth = 52;
            int labelHeight = 29;

            Size labelSize = new Size(labelWidth, labelHeight);

            //draw page
            Point startPoint = new Point(0, 0);
            Size pageSize = new Size(pageWidth, pageHeight);
            Rectangle page = new Rectangle(startPoint, pageSize);
            g.DrawRectangle(p, page);
            g.FillRectangle(Brushes.White, page);

            //draw label
            int labelsOnPage = columns * rows;
            int currentColumn = 0;
            int currentRow = 0;

            while (currentRow < rows)
            {
                Point labelLocation = new Point(labelWidth * currentColumn, labelHeight * currentRow);
                int labelCenter = labelLocation.X + labelWidth / 2;
                Rectangle label = new Rectangle(labelLocation, labelSize);

                if (code == 0)
                {
                    municipalLabel(g);
                }
                else if (code == 1)
                {
                    infectiousLabel(g);
                }

                g.DrawRectangle(labelBorder, label);
                currentColumn++;
                if (currentColumn % 4 == 0)
                {
                    currentColumn = 0;
                    currentRow++;
                }
            }

            void municipalLabel(Graphics g)
            {
                Point ptGarbageType = new Point(labelCenter, labelLocation.Y + 3);
                Point ptCompanyName = new Point(labelCenter, labelLocation.Y + 7);
                Point ptCompanyNameCd = new Point(labelCenter, labelLocation.Y + 10);
                Point ptUnitName = new Point(labelCenter, labelLocation.Y + 14);
                Point ptCloseDate = new Point(labelCenter, labelLocation.Y + 22);

                g.DrawString(GarbageType, fontBold, brush, ptGarbageType, stringFormat);
                g.DrawString(Company.NameLine0, fontSmall, brush, ptCompanyName, stringFormat);
                g.DrawString(Company.NameLine1, fontSmall, brush, ptCompanyNameCd, stringFormat);
                g.DrawString(UnitName, fontBold, brush, ptUnitName, stringFormat);
                g.DrawString("Data zamknięcia", fontSmall, brush, ptCloseDate, stringFormat);
            }

            void infectiousLabel(Graphics g)
            {
                Point ptGarbageType = new Point(labelCenter, labelLocation.Y + 3);
                Point ptCompanyName = new Point(labelCenter, labelLocation.Y + 7);
                Point ptCompanyNameCd = new Point(labelCenter, labelLocation.Y + 9);
                Point ptUnitName = new Point(labelCenter, labelLocation.Y + 11);
                Point ptRegon = new Point(labelCenter, labelLocation.Y + 15);
                Point ptRegistrationBook = new Point(labelCenter, labelLocation.Y + 17);
                Point ptRegistrationAuthority = new Point(labelCenter, labelLocation.Y + 19);
                Point ptOpenDate = new Point(labelLocation.X + 13, labelLocation.Y + 22);
                Point ptCloseDate = new Point(labelLocation.X + labelWidth - 13, labelLocation.Y + 22);

                g.DrawString(GarbageType, fontBold, brush, ptGarbageType, stringFormat);
                g.DrawString(Company.NameLine0, fontSmall, brush, ptCompanyName, stringFormat);
                g.DrawString(Company.NameLine1, fontSmall, brush, ptCompanyNameCd, stringFormat);
                g.DrawString(UnitName, fontBold, brush, ptUnitName, stringFormat);
                g.DrawString("REGON " + Company.REGON, fontSmall, brush, ptRegon, stringFormat);
                g.DrawString("Nr Ks. Rej. " + Company.RegistrationBookNumber, fontSmall, brush, ptRegistrationBook, stringFormat);
                g.DrawString("Oragan rejestrowy " + Company.RegistrationAuthority, fontSmall, brush, ptRegistrationAuthority, stringFormat);
                g.DrawString("Data otwarcia", fontSmall, brush, ptOpenDate, stringFormat);
                g.DrawString("Data zamknięcia", fontSmall, brush, ptCloseDate, stringFormat);
            }
        }
    }
}
