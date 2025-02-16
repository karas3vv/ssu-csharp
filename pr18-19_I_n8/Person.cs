using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace pr17_18_I_n8
{
    internal class Person : PhoneDirectoryItem
    {
        public Person(string name, string address, string phoneNumber): base(name, address, phoneNumber)
        {
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}, Address: {Address}, Phone Number: {PhoneNumber}");
        }

        public override bool MatchesSearchCriterion(string criteria)
        {
            return Name.Equals(criteria, StringComparison.OrdinalIgnoreCase);
        }
    }
}
