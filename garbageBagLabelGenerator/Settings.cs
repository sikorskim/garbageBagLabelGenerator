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
        public List<string> GarabageTypes { get; set; }
        public string Path { get; set; }

        public Settings(string path)
        {
            Path = path;
            Units = new List<string>();
            GarabageTypes = new List<string>();
            importFromXML(path);
        }

        void importFromXML(string path)
        {
                XDocument doc = XDocument.Load(path);
                XElement elemCompany = doc.Element("Settings").Element("Company");
                XElement elemGarbageTypes = doc.Element("Settings").Element("Company").Element("GarbageTypes");
                XElement elemUnits = doc.Element("Settings").Element("Company").Element("Units");
                Company = Company.get(elemCompany);

                foreach (XElement elem in elemGarbageTypes.Elements("GarbageType"))
                {
                    GarabageTypes.Add(elem.Value);
                }

                foreach (XElement elem in elemUnits.Elements("Unit"))
                {
                    Units.Add(elem.Value);
                }
        }
    }
}
