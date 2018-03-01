using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace garbageBagLabelGenerator
{
    public class Settings
    {
        public Company Company { get; set; }
        public List<string> Units { get; set; }
        public List<Label> Labels { get; set; }
        public string Path { get; set; }

        public Settings(string path)
        {
            Path = path;
            Units = new List<string>();
            Labels = new List<Label>();
        }

        public bool importFromXML()
        {
            try
            {
                XDocument doc = XDocument.Load(Path);
                XElement elemCompany = doc.Element("Settings").Element("Company");
                XElement elemUnits = doc.Element("Settings").Element("Company").Element("Units");
                XElement elemLabels = doc.Element("Settings").Element("Labels");
                Company = Company.get(elemCompany);

                foreach (XElement unit in elemUnits.Elements("Unit"))
                {
                    Units.Add(unit.Value);
                }

                foreach (XElement label in elemLabels.Elements("Label"))
                {
                    Label tmpLabel = new Label();
                    tmpLabel=tmpLabel.get(label);
                    Labels.Add(tmpLabel);
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
