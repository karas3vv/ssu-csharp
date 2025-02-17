using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr17_18_I_n8
{
    internal class Program
    {
        static void Main()
        {
            PhoneDirectory directory = new PhoneDirectory();
            directory.LoadDataFromFile("D:/Projects/ssu-csharp/pr18-19_I_n8/input.txt");

            directory.SortByPhoneNumber();

            Console.WriteLine("\nПолная информация из базы данных, отсортированная по номеру телефона:");
            directory.DisplayAllItems();

            Console.Write("\nВведите фамилию: ");
            string nameToSearch = Console.ReadLine();

            var searchResults = directory.SearchByName(nameToSearch);

            if (searchResults.Count > 0)
            {
                Console.WriteLine("\nНайденные записи:");
                foreach (var item in searchResults)
                {
                    item.DisplayInfo();
                }
            }
            else
            {
                Console.WriteLine("\nЗаписи не найдены");
            }
        }
    }
}
