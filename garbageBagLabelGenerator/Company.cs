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
    }
}
