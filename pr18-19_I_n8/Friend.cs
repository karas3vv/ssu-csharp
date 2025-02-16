using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr17_18_I_n8
{
    internal class Friend : Person
    {
        public DateTime DateOfBirth { get; set; }

        public Friend(string name, string address, string phoneNumber, DateTime dateOfBirth)
            : base(name, address, phoneNumber)
        {
            DateOfBirth = dateOfBirth;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}, Address: {Address}, Phone Number: {PhoneNumber}, Date of Birth: {DateOfBirth.ToShortDateString()}");
        }

        public override bool MatchesSearchCriterion(string criteria)
        {
            return Name.Equals(criteria, StringComparison.OrdinalIgnoreCase);
        }
    }
}
