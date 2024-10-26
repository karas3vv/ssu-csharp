using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr9_II_n18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file1 = "file1.txt";
            string file2 = "file2.txt";
            string resultPath = "result.txt";

            try
            {
                // Читаем числа из файлов и преобразуем в массивы
                int[] numbers1 = File.ReadAllLines(file1).Select(int.Parse).ToArray();
                int[] numbers2 = File.ReadAllLines(file2).Select(int.Parse).ToArray();

                // Проверяем, что файлы имеют одинаковое количество чисел
                if (numbers1.Length != numbers2.Length)
                {
                    Console.WriteLine("Файлы содержат разное количество чисел.");
                    return;
                }

                using (StreamWriter writer = new StreamWriter(resultPath))
                {
                    for (int i = 0; i < numbers1.Length; i++)
                    {
                        int num1 = numbers1[i];
                        int num2 = numbers2[i];

                        // Проверяем делимость и записываем частное в новый файл, если делится
                        if (num1 % num2 == 0)
                        {
                            writer.WriteLine(num1 / num2);
                        }
                        else if (num2 % num1 == 0)
                        {
                            writer.WriteLine(num2 / num1);
                        }
                    }
                }

                Console.WriteLine("Результат записан в файл: " + resultPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
    }
}
