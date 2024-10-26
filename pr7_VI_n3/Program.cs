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

            // Создаем ступенчатый массив
            int[][] array = new int[rows][];

            for (int i = 0; i < rows; i++) {
                array[i] = new int[rows];

                Console.WriteLine($"Введите элементы строки {i + 1} через пробел:");
                string[] elements = Console.ReadLine().Split(' ');
                for (int j = 0; j < rows; j++)
                {
                    array[i][j] = int.Parse(elements[j]);
                }
            }

            // Перебор строк в массиве и вставка строк с нулями
            for (int i = 0; i < array.Length; i++)
            {
                bool hasEven = false;
                foreach (var element in array[i])
                {
                    if (element % 2 == 0)
                    {
                        hasEven = true;
                        break;
                    }
                }

                // Если четных элементов нет, то вставляем строку с нулями
                if (!hasEven)
                {
                    int[] zeroRow = new int[array[i].Length];

                    // Увеличиваем размер массива и сдвигаем строки вниз
                    Array.Resize(ref array, array.Length + 1);
                    for (int j = array.Length - 1; j > i + 1; j--)
                    {
                        array[j] = array[j - 1];
                    }

                    // Вставляем строку с нулями после текущей строки
                    array[i + 1] = zeroRow;

                    // Пропускаем добавленную строку с нулями
                    i++;
                }
            }
            // Вывод результата
            Console.WriteLine("Результат:");
            foreach (var row in array)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }    
    }
}