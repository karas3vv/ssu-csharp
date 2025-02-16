using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr17_18_I_n8
{
    internal class Person : PhoneDirectory
    {
        public Person(string lastName, string address, string phoneNumber)
        {
            LastName = lastName;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Персона: {LastName}, Адрес: {Address}, Телефон: {PhoneNumber}");
        }

        public override bool MatchesCriterion(string criterion)
        {
            return LastName.Contains(criterion);
        }
    }
}
