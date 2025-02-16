using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace pr17_18_I_n8
{
    internal class Friend : PhoneDirectory
    {
        public string BirthDate { get; set; }

        public Friend(string lastName, string address, string phoneNumber, string birthDate)
        {
            LastName = lastName;
            Address = address;
            PhoneNumber = phoneNumber;
            BirthDate = birthDate;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Друг: {LastName}, Адрес: {Address}, Телефон: {PhoneNumber}, Дата рождения: {BirthDate}");
        }

        public override bool MatchesCriterion(string criterion)
        {
            return LastName.Contains(criterion);
        }
    }
}
