using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr14_II_n8
{
    public class Contributor : IComparable<Contributor>
    {
        public string FullName { get; set; }
        public string AccountNumber { get; set; }
        public double Amount { get; set; }
        public int OpeningYear { get; set; }

        public Contributor(string fullName, string accountNumber, double amount, int openingYear)
        {
            FullName = fullName;
            AccountNumber = accountNumber;
            Amount = amount;
            OpeningYear = openingYear;
        }

        // Реализация метода CompareTo для сортировки по сумме вклада (по убыванию)
        public int CompareTo(Contributor other)
        {
            return -this.Amount.CompareTo(other.Amount);
        }

        public override string ToString()
        {
            return $"{FullName}, {AccountNumber}, {Amount:C}, {OpeningYear}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Contributor> contributors = new List<Contributor>();
            using(StreamReader reader = new StreamReader("D:/Projects/C#/pr14_II_n8/input.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 4)
                    {
                        string fullName = parts[0].Trim();
                        string accountNumber = parts[1].Trim();
                        double amount = double.Parse(parts[2].Trim());
                        int openingYear = int.Parse(parts[3].Trim());

                        contributors.Add(new Contributor(fullName,  accountNumber, amount, openingYear));
                    } 
                }
            }

            // Получение текущего года
            int currentYear = DateTime.Now.Year;

            // Фильтрация вкладчиков, открывших счет в текущем году
            List<Contributor> currentYearContributors = contributors.FindAll(c => c.OpeningYear == currentYear);

            // Сортировка по сумме вклада
            currentYearContributors.Sort();

            using (StreamWriter writer = new StreamWriter("D:/Projects/C#/pr14_II_n8/output.txt"))
            {
                foreach (var contributor in currentYearContributors)
                {
                    writer.WriteLine(contributor.ToString());
                }
            }

            Console.WriteLine("Данные успешно записаны в файл output.txt");
        }
    }
}