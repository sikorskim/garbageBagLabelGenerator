using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace garbageBagLabelGenerator.Classes
{
    class Content
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Font { get; set; }
        public int FontSize { get; set; }
        public bool Bold { get; set; }
        public bool Cursive { get; set; }
        public bool Underline { get; set; }
        public string TextAlignment { get; set; }
        public int MarginTop { get; set; }
    }
}
