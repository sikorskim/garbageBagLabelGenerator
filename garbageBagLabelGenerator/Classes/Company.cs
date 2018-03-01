using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace garbageBagLabelGenerator
{
    public class Company
    {
        public string Name { get; set; }
        public string REGON{get; set; }
        public string RegistrationBookNumber { get; set; }
        public string RegistrationAuthority { get; set; }
        public virtual string NameLine0 { get { return getNameLine0(); } }
        public virtual string NameLine1 { get { return getNameLine1(); } }

        public Company(string name, string regon, string registrationBookNumber, string registrationAuthority)
        {
            Name = name;
            REGON = regon;
            RegistrationBookNumber = registrationBookNumber;
            RegistrationAuthority = registrationAuthority;
        }

        public static Company get(XElement companyData)
        {
            string name = companyData.Attribute("Name").Value;
            string regon = companyData.Attribute("REGON").Value;
            string registrationBookNumber = companyData.Attribute("RegistrationBookNumber").Value;
            string registrationAuthority = companyData.Attribute("RegistrationAuthority").Value;
            Company company = new Company(name, regon, registrationBookNumber, registrationAuthority);

            return company;
        }

        string getNameLine0()
        {
            string line0 = "";
            if (Name.Length > 30)
            {
                line0 = Name.Substring(0, 22);
            }
                return line0;
        }

        string getNameLine1()
        {
            string line1 = "";
            if (Name.Length > 30)
            {
                line1 = Name.Substring(21, Name.Length - 21);
            }
            return line1;
        }
    }
}
