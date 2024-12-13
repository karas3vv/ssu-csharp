using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr16_I_n19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Список для хранения чисел
            List<int> numbers = new List<int>();


            using (StreamReader reader = new StreamReader("D:/Projects/ssu-csharp/pr16_I_n19/input.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Разбиение строки на числа и добавление в список
                    var lineNumbers = line.Split(new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                                          .Where(item => int.TryParse(item, out _)) // Фильтрация корректных чисел
                                          .Select(int.Parse);
                    numbers.AddRange(lineNumbers);
                }
            }

            var result = numbers
                        .Where(n => n % 2 == 0)               // Фильтрация четных чисел
                        .OrderBy(n => n)                      // Сортировка по возрастанию
                        .Select(n => n > 0 ? n / 2 : n * 2)   // Уменьшение каждого числа в два раза
                        .ToArray();


            // Запись результата в файл
            using (StreamWriter writer = new StreamWriter("D:/Projects/ssu-csharp/pr16_I_n19/output.txt"))
            {
                foreach (var number in result)
                {
                    writer.WriteLine(number);
                }
            }

            Console.WriteLine("Результат сохранен в файл output.txt");
        }
    }
}