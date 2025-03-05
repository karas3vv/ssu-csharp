using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace pr17_18_I_n8
{
    [Serializable]
    internal class Person : PhoneDirectoryItem
    {
        public Person(string name, string address, string phoneNumber) : base(name, address, phoneNumber)
        {
        }
        public override string ToStr()
        {
            StringBuilder res = new StringBuilder();

            res.AppendLine();
            res.AppendLine("Персона");
            res.AppendLine("Имя: " + Name);
            res.AppendLine("Адрес: " + Address);
            res.AppendLine("Номер телефона: " + PhoneNumber);

            return res.ToString();
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Персона: {Name}, Адрес: {Address}, Номер телефона: {PhoneNumber}");
        }

        public override bool MatchesSearchCriterion(string criterion)
        {
            return Name.Equals(criterion, StringComparison.OrdinalIgnoreCase);
        }
    }
}
