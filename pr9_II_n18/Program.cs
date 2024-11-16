using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace pr9_II_n18
{
    class Program
    {
        static void Main(string[] args)
        {
            // Открываем файлы для чтения
            using (StreamReader reader1 = new StreamReader("D:/Projects/C#/pr9_II_n18/file1.txt"))
            {
                using (StreamReader reader2 = new StreamReader("D:/Projects/C#/pr9_II_n18/file2.txt"))
                {
                    using (StreamWriter resultFile = new StreamWriter("D:/Projects/C#/pr9_II_n18/result.txt"))
                    {
                        char[] separators = { ' ', '\t', '\n', '\r' };
                        string line1, line2;

                        // Читаем построчно до конца файлов
                        int[] numbers1 = { };
                        while ((line1 = reader1.ReadLine()) != null)
                        {
                            string[] temp = line1.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                            for (int i = 0; i < temp.Length; ++i)
                            {
                                Array.Resize(ref numbers1, numbers1.Length + 1);
                                numbers1[numbers1.Length - 1] = int.Parse(temp[i]);
                            }
                        }

                        int[] numbers2 = { };
                        while ((line2 = reader2.ReadLine()) != null)
                        {
                            string[] temp = line2.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                            for (int i = 0; i < temp.Length; ++i)
                            {
                                Array.Resize(ref numbers2, numbers2.Length + 1);
                                numbers2[numbers2.Length - 1] = int.Parse(temp[i]);
                            }
                        }

                        // Запись данных в файл
                        for (int i = 0; i < numbers1.Length; ++i)
                        {
                            // Проверка делимости
                            if (numbers1[i] != 0 && numbers1[i] % numbers2[i] == 0)
                            {
                                resultFile.WriteLine(numbers1[i] / numbers2[i]);
                            }
                            else if (numbers2[i] != 0 && numbers2[i] % numbers1[i] == 0)
                            {
                                resultFile.WriteLine(numbers2[i] / numbers1[i]);
                            }
                        }
                    }
                    Console.WriteLine("Результат записан в файл result.txt");
                }
            }
        }

    }
}               