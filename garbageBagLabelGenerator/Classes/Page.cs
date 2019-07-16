using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace garbageBagLabelGenerator.Classes
{
    class Page
    {
        public Size Size { get; set; }
        public int Columns { get; set; }
        public int Rows { get; set; }
        public int MarginLeft { get; set; }
        public int MarginTop { get; set; }
        public int MarginBottom { get; set; }
        public int MarginRight { get; set; }

    }
}
