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
        public List<Unit> Units { get; set; }
        public List<Label> Labels { get; set; }
        public string Path { get; set; }

        public Settings(string path)
        {
            Path = path;
            Units = new List<Unit>();
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

                foreach (XElement xUnit in elemUnits.Elements("Unit"))
                {
                    Unit unit = new Unit();
                    unit = unit.get(xUnit);
                    Units.Add(unit);
                }

                foreach (XElement xLabel in elemLabels.Elements("Label"))
                {
                    Label label = new Label();
                    label=label.get(xLabel);
                    Labels.Add(label);
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
