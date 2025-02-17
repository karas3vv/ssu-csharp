using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr17_18_I_n8
{
    internal class Organization : PhoneDirectoryItem
    {
        public string OrganizationName { get; set; } 
        public string Fax { get; set; }

        public Organization(string organizationName, string address, string phoneNumber, string fax, string name): base(name, address, phoneNumber)
        {
            OrganizationName = organizationName;
            Fax = fax;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Организация: {OrganizationName}, Адрес: {Address}, Номер телеофна: {PhoneNumber}, Факс: {Fax}, Контактное лицо: {Name}");
        }

        public override bool MatchesSearchCriterion(string criteriion)
        {
            return Name.Equals(criteriion, StringComparison.OrdinalIgnoreCase);
        }
    }
}
