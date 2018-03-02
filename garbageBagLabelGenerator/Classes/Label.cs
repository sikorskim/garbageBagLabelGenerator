using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace garbageBagLabelGenerator
{
    public class Label
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Columns { get; private set; }
        public int Rows { get; private set; }
        public int MarginLeft { get; private set; }
        public int MarginTop { get; private set; }
        public Size Size { get; private set; }
        public Size PageSize { get; private set; }
        public int FontDefaultSize { get; private set; }
        public int FontSmallSize { get; private set; }

        public Label()
        { }      

        public Label get(XElement label)
        {
            Id = Int32.Parse(label.Attribute("Id").Value);
            Name = label.Attribute("Name").Value;
            Columns = Int32.Parse(label.Attribute("Columns").Value);
            Rows = Int32.Parse(label.Attribute("Rows").Value);
            MarginLeft= Int32.Parse(label.Attribute("MarginLeft").Value);
            MarginTop = Int32.Parse(label.Attribute("MarginTop").Value);

            int width= Int32.Parse(label.Attribute("Width").Value);
            int height = Int32.Parse(label.Attribute("Height").Value);
            Size = new Size(width, height);

            int pageWidth = Int32.Parse(label.Attribute("PageWidth").Value);
            int pageHeight = Int32.Parse(label.Attribute("PageHeight").Value);
            PageSize = new Size(width, height);

            FontDefaultSize= Int32.Parse(label.Attribute("FontSizeDefault").Value);
            FontSmallSize = Int32.Parse(label.Attribute("FontSizeSmall").Value);

            return this;
        }
    }
}
