using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace garbageBagLabelGenerator
{
    class Label
    {
        public int Columns { get; private set; }
        public int Rows { get; private set; }
        public int MarginLeft { get; private set; }
        public int MarginTop { get; private set; }
        public Size Size { get; private set; }
        public Size PageSize { get; private set; }

        public Label()
        { }      

        public Label getStandard()
        {
            Columns = 4;
            Rows = 10;
            MarginLeft = 0;
            MarginTop = 0;
            Size = new Size(52, 29);
            PageSize = new Size(210,297);
            return this;
        }
    }
}
