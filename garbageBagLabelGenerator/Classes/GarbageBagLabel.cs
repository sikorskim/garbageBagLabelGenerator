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
        public Label Label { get; set; }

        public GarbageBagLabel(string garbageType, Company company, string unitName, Label label)
        {
            GarbageType = garbageType;
            Company = company;
            UnitName = unitName;
            Label = label;
            
        }

        public void print(System.Drawing.Printing.PrintPageEventArgs e, int labelCode)
        {
            Graphics g = e.Graphics;
            draw(g, labelCode);
        }

        void draw(Graphics g, int code)
        {
            //g.PageUnit = GraphicsUnit.Millimeter;
            //float lineSize = 0.2f;
            //Pen p = new Pen(Color.White, lineSize);
            //Pen labelBorder = new Pen(Color.White, 0);

            ////font settings

            //Font fontDefault = new Font("Times New Roman", 10);
            //Font fontSmall = new Font("Times New Roman", 10);
            //Font fontBold = new Font("Times New Roman", 10, FontStyle.Bold);
            //Brush brush = Brushes.Black;
            //StringFormat stringFormat = new StringFormat();
            //stringFormat.Alignment = StringAlignment.Center;

            ////draw page
            //Point startPoint = new Point(0, 0);
            //Rectangle page = new Rectangle(startPoint, Label.PageSize);
            //g.DrawRectangle(p, page);
            //g.FillRectangle(Brushes.White, page);

            ////draw label
            //int currentColumn = 0;
            //int currentRow = 0;
            
            //while (currentRow < Label.Rows)
            //{
            //    Point labelLocation = new Point();
            //    //labelLocation = new Point(Label.Size.Width * currentColumn, Label.Size.Height * currentRow);
            //    labelLocation.X = Label.Size.Width * currentColumn + Label.MarginLeft-5;
            //    labelLocation.Y = Label.Size.Height * currentRow + Label.MarginTop;
            //    Rectangle label = new Rectangle(labelLocation, Label.Size);
            //    int labelCenter = labelLocation.X + Label.Size.Width / 2;

            //    if (code == 0)
            //    {
            //        Point ptGarbageType = new Point(labelCenter, labelLocation.Y + 3);
            //        Point ptCompanyName = new Point(labelCenter, labelLocation.Y + 7);
            //        Point ptCompanyNameCd = new Point(labelCenter, labelLocation.Y + 10);
            //        Point ptUnitName = new Point(labelCenter, labelLocation.Y + 14);
            //        Point ptCloseDate = new Point(labelCenter, labelLocation.Y + 22);

            //        g.DrawString(GarbageType, fontBold, brush, ptGarbageType, stringFormat);
            //        g.DrawString(Company.NameLine0, fontSmall, brush, ptCompanyName, stringFormat);
            //        g.DrawString(Company.NameLine1, fontSmall, brush, ptCompanyNameCd, stringFormat);
            //        g.DrawString(UnitName, fontBold, brush, ptUnitName, stringFormat);
            //        g.DrawString("Data zamknięcia", fontSmall, brush, ptCloseDate, stringFormat);
            //    }
            //    else if (code == 1 && Label.Id == 0)
            //    {
            //        Point ptGarbageType = new Point(labelCenter, labelLocation.Y + 3);
            //        Point ptCompanyName = new Point(labelCenter, labelLocation.Y + 7);
            //        Point ptCompanyNameCd = new Point(labelCenter, labelLocation.Y + 9);
            //        Point ptUnitName = new Point(labelCenter, labelLocation.Y + 11);
            //        Point ptRegon = new Point(labelCenter, labelLocation.Y + 15);
            //        Point ptRegistrationBook = new Point(labelCenter, labelLocation.Y + 17);
            //        Point ptRegistrationAuthority = new Point(labelCenter, labelLocation.Y + 19);
            //        Point ptOpenDate = new Point(labelLocation.X + 13, labelLocation.Y + 22);
            //        Point ptCloseDate = new Point(labelLocation.X + Label.Size.Width - 13, labelLocation.Y + 22);

            //        g.DrawString(GarbageType, fontBold, brush, ptGarbageType, stringFormat);
            //        g.DrawString(Company.NameLine0, fontSmall, brush, ptCompanyName, stringFormat);
            //        g.DrawString(Company.NameLine1, fontSmall, brush, ptCompanyNameCd, stringFormat);
            //        g.DrawString(UnitName, fontBold, brush, ptUnitName, stringFormat);
            //        g.DrawString("REGON " + Company.REGON, fontSmall, brush, ptRegon, stringFormat);
            //        g.DrawString("Nr Ks. Rej. " + Company.RegistrationBookNumber, fontSmall, brush, ptRegistrationBook, stringFormat);
            //        g.DrawString("Oragan rejestrowy " + Company.RegistrationAuthority, fontSmall, brush, ptRegistrationAuthority, stringFormat);
            //        g.DrawString("Data otwarcia", fontSmall, brush, ptOpenDate, stringFormat);
            //        g.DrawString("Data zamknięcia", fontSmall, brush, ptCloseDate, stringFormat);
            //    }
            //    else if (code == 1 && Label.Id == 1)
            //    {
            //        Point ptGarbageType = new Point(labelCenter, labelLocation.Y + 5);
            //        Point ptCompanyName = new Point(labelCenter, labelLocation.Y + 10);
            //        Point ptCompanyNameCd = new Point(labelCenter, labelLocation.Y + 15);
            //        Point ptUnitName = new Point(labelCenter, labelLocation.Y + 20);
            //        Point ptRegon = new Point(labelCenter, labelLocation.Y + 25);
            //        Point ptRegistrationBook = new Point(labelCenter, labelLocation.Y + 30);
            //        Point ptRegistrationAuthority = new Point(labelCenter, labelLocation.Y + 35);
            //        Point ptOpenDate = new Point(labelLocation.X + 15, labelLocation.Y + 45);
            //        Point ptCloseDate = new Point(labelLocation.X + Label.Size.Width - 13, labelLocation.Y + 45);

            //        g.DrawString(GarbageType, fontBold, brush, ptGarbageType, stringFormat);
            //        g.DrawString(Company.NameLine0, fontSmall, brush, ptCompanyName, stringFormat);
            //        g.DrawString(Company.NameLine1, fontSmall, brush, ptCompanyNameCd, stringFormat);
            //        g.DrawString(UnitName, fontBold, brush, ptUnitName, stringFormat);
            //        g.DrawString("REGON " + Company.REGON, fontSmall, brush, ptRegon, stringFormat);
            //        g.DrawString("Nr Ks. Rej. " + Company.RegistrationBookNumber, fontSmall, brush, ptRegistrationBook, stringFormat);
            //        g.DrawString("Oragan rejestrowy " + Company.RegistrationAuthority, fontSmall, brush, ptRegistrationAuthority, stringFormat);
            //        g.DrawString("Data i godzina\n otwarcia", fontSmall, brush, ptOpenDate, stringFormat);
            //        g.DrawString("Data i godzina\n zamknięcia", fontSmall, brush, ptCloseDate, stringFormat);
            //    }

            //    g.DrawRectangle(labelBorder, label);
            //    currentColumn++;
            //    if (currentColumn % Label.Columns == 0)
            //    {
            //        currentColumn = 0;
            //        currentRow++;
            //    }
            //}
        }
    }
}
