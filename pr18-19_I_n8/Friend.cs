using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace pr17_18_I_n8
{
    [Serializable]
    internal class Friend : PhoneDirectoryItem
    {
        public DateTime DateOfBirth { get; set; }

        public Friend(string name, string address, string phoneNumber, string dateOfBirth): base(name, address, phoneNumber)
        {
            if (DateTime.TryParse(dateOfBirth, out DateTime parsedDate))
            {
                DateOfBirth = parsedDate; // Преобразуем строку в DateTime
            }
        }

        public override string ToStr()
        {
            StringBuilder res = new StringBuilder();

            res.AppendLine();
            res.AppendLine("Друг");
            res.AppendLine("Имя: " + Name);
            res.AppendLine("Адрес: " + Address);
            res.AppendLine("Номер телефона: " + PhoneNumber);
            res.AppendLine("Дата ДР: " + DateOfBirth);

            return res.ToString();
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
