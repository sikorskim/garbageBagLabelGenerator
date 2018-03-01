using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace garbageBagLabelGenerator
{
    public class Unit
    {
        public string Name { get; set; }

        public Unit()
        { }

        public Unit get(XElement unit)
        {
            Name = unit.Value;
            return this;
        }
    }
}
