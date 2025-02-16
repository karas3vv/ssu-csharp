using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr17_18_I_n8
{
    internal class Program
    {
        private static readonly string pathInput = "D:/Projects/ssu-csharp/pr18-19_I_n8/input.txt";
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(pathInput);

            // создаем массив записей
            PhoneDirectory[] database = new PhoneDirectory[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(';');
                switch (parts[0])
                {
                    case "Персона":
                        database[i] = new Person(parts[1], parts[2], parts[3]);
                        break;
                    case "Организация":
                        database[i] = new Organization(parts[1], parts[2], parts[3], parts[4], parts[5]);
                        break;
                    case "Друг":
                        database[i] = new Friend(parts[1], parts[2], parts[3], parts[4]);
                        break;
                }
            }

            // сортировка бд по номеру телефона
            Array.Sort(database);

            // вывод полной информации из бд
            Console.WriteLine("База данных (отсортированна по номеру телефона)");
            foreach (var entry in database)
            {
                entry.PrintInfo();
            }

            // поиск по фамилии
            Console.WriteLine("\nВведите фамилию:");
            string criterion = Console.ReadLine();

            using (StreamWriter writer = new StreamWriter("D:/Projects/ssu-csharp/pr18-19_I_n8/output.txt"))
            {
                writer.WriteLine("Результат:");
                foreach (var entry in database)
                {
                    if (entry.MatchesCriterion(criterion))
                    {
                        entry.PrintInfo();
                        writer.WriteLine($"{entry.GetType().Name}: {entry.LastName}, {entry.Address}, {entry.PhoneNumber}");
                    }
                }
            }

            Console.WriteLine("Результат записан в output.txt");
        }
    }
}
