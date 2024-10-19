using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr7_IV_n18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива n: ");
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            Console.WriteLine("Введите элементы массива (по строкам):");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"Введите элемент [{i + 1}, {j + 1}]: ");
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }

            // Массив для хранения произведений столбцов
            int[] columnProducts = new int[n];

            // Инициализация массива произведений единицами (чтобы не умножать на 0)
            for (int j = 0; j < n; j++)
            {
                columnProducts[j] = 1;
            }

            // Подсчет произведений элементов каждого столбца
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    columnProducts[j] *= matrix[i, j];
                }
            }

            Console.WriteLine("\nПроизведение элементов каждого столбца:");
            foreach (int product in columnProducts)
            {
                Console.Write(product + " ");
            }

            // Поиск минимального элемента в массиве произведений
            int minProduct = columnProducts[0];
            for (int i = 1; i < columnProducts.Length; i++)
            {
                if (columnProducts[i] < minProduct)
                {
                    minProduct = columnProducts[i];
                }
            }

            Console.WriteLine($"\n\nМинимальное произведение: {minProduct}");
        }
    }
}
