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

        public Friend(string name, string address, string phoneNumber, DateTime dateOfBirth): base(name, address, phoneNumber)
        {
            DateOfBirth = dateOfBirth;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Друг: {Name}, Адрес: {Address}, Номер телефона: {PhoneNumber}, Дата ДР: {DateOfBirth.ToShortDateString()}");
        }

        public override bool MatchesSearchCriterion(string criterion)
        {
            return Name.Equals(criterion, StringComparison.OrdinalIgnoreCase);
        }
    }
}
