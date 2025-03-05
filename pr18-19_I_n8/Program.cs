using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Net;
using System.Xml.Linq;
using System.Text.RegularExpressions;

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

        //static void Print(List<PhoneDirectoryItem> objects)
        //{
        //    using (StreamWriter fileOut = new StreamWriter("D:/Projects/ssu-csharp/pr18-19_I_n8/ser.txt", false))
        //    {
        //        Console.WriteLine("Открытие файла ser.txt");
        //        if (objects.Count == 0)
        //            fileOut.WriteLine("Список объектов пуст.");
        //        else
        //        {
        //            fileOut.WriteLine("Список объектов:");
        //            foreach (PhoneDirectoryItem item in objects)
        //            {
        //                fileOut.WriteLine(item.ToStr());
        //            }
        //        }
        //        Console.WriteLine("Закрытие файла ser.txt");
        //    }
        //}

        //static void Main(string[] args)
        //{
        //    List<PhoneDirectoryItem> objects = new List<PhoneDirectoryItem>();

        //    BinaryFormatter formatter = new BinaryFormatter();

        //    using (FileStream f = new FileStream("D:/Projects/ssu-csharp/pr18-19_I_n8/input.dat",
        //        FileMode.OpenOrCreate))
        //    {
        //        if (f.Length != 0)
        //        {
        //            Console.WriteLine("Файл с серилизованными данными успешно подгружен.");
        //            objects = (List<PhoneDirectoryItem>)formatter.Deserialize(f);
        //        }
        //        else
        //            Console.WriteLine("Файл с серилизованными данными не найден. ");
        //    }

        //    objects.Add(new Person("Иванов", "ул.Ленина", "89053809815"));
        //    objects.Add(new Organization("ООО Рога и Копыта", "ул.Мира", "89959895567", "1234567890", "Петров"));
        //    objects.Add(new Friend("Сидоров", "ул.Советская", "88033754553", "1991/7/12"));
        //    objects.Add(new Person("Карасев", "ул.Танкистов", "89622344556"));
        //    objects.Add(new Organization("ОАО Вшора", "ул.Пушкина", "89853893468", "1231567690", "Коновалов"));
        //    objects.Add(new Friend("Пицик", "ул.Горького", "89277893501", "2002/4/25"));


        //    objects.Sort();
        //    Print(objects);

        //    using (FileStream f = new FileStream("D:/Projects/ssu-csharp/pr18-19_I_n8/input.dat",
        //        FileMode.OpenOrCreate))
        //        formatter.Serialize(f, objects);
        //}
    }
}
