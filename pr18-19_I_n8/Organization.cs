using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr17_18_I_n8
{
    internal class Organization : PhoneDirectory 
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public override string PhoneNumber { get; set; }
        public string Fax { get; set; }
        public string ContactPerson { get; set; }

        public Organization(string name, string address, string phone, string fax, string contactPerson)
        {
            Name = name;
            Address = address;
            PhoneNumber = phone;
            Fax = fax;
            ContactPerson = contactPerson;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Организация: {Name}, Адрес: {Address}, Телефон: {PhoneNumber}, Факс: {Fax}, Контактное лицо: {ContactPerson}");
        }

        public override bool MatchesCriterion(string criterion)
        {
            return Name.Contains(criterion) || ContactPerson.Contains(criterion);
        }
    }
}
