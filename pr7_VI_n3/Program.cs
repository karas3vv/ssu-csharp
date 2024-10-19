using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr7_VI_n3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество строк: ");
            int rows = int.Parse(Console.ReadLine());

            int[][] array = new int[rows][];

            for (int i = 0; i < rows; i++) {
                //Console.Write($"Введите количество элементов в строке {i + 1}: ");
                //int cols = int.Parse(Console.ReadLine());
                array[i] = new int[rows];

                Console.WriteLine($"Введите элементы строки {i + 1} через пробел:");
                string[] elements = Console.ReadLine().Split(' ');
                for (int j = 0; j < rows; j++)
                {
                    array[i][j] = int.Parse(elements[j]);
                }
            }

            // Новый список для хранения строк, включая добавленные
            var resultList = new System.Collections.Generic.List<int[]>();

            foreach (var row  in array)
            {
                resultList.Add(row);

                // Проверка на четные элементы в стркое
                bool hasEven = false;
                foreach (var element in row)
                {
                    if (element % 2 == 0)
                    {
                        hasEven = true;
                        break;
                    }
                }
                if (!hasEven)
                {
                    int[] zeroRow = new int[row.Length];
                    resultList.Add(zeroRow);
                }
            }

            Console.WriteLine("Результат:");
            foreach (var row in resultList)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }    
    }
}