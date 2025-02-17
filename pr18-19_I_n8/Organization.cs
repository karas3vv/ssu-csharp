using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr17_18_I_n8
{
    internal class Organization : PhoneDirectoryItem
    {
        public string Fax { get; set; }
        public string ContactPerson { get; set; }

        public Organization(string name, string address, string phoneNumber, string fax, string contactPerson)
            : base(name, address, phoneNumber)
        {
            Fax = fax;
            ContactPerson = contactPerson;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Organization: {Name}, Address: {Address}, Phone Number: {PhoneNumber}, Fax: {Fax}, Contact Person: {ContactPerson}");
        }

        public override bool MatchesSearchCriterion(string criterion)
        {
            return Name.Equals(criterion, StringComparison.OrdinalIgnoreCase);
        }
    }
}
