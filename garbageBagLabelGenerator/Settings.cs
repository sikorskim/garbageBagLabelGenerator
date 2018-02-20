using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace garbageBagLabelGenerator
{
    class Settings
    {
        public Company Company { get; set; }
        public List<string> Units { get; set; }
        public string Path { get; set; }

        public Settings(string path)
        {
            Path = path;
            Units = new List<string>();
        }

        public bool importFromXML()
        {
            try
            {
                XDocument doc = XDocument.Load(Path);
                XElement elemCompany = doc.Element("Settings").Element("Company");
                XElement elemUnits = doc.Element("Settings").Element("Company").Element("Units");
                Company = Company.get(elemCompany);

                foreach (XElement elem in elemUnits.Elements("Unit"))
                {
                    Units.Add(elem.Value);
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
