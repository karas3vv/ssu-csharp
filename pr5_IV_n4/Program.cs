using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr5_IV_n4
{
    internal class Program
    {
        static void PrintLine(int value, int count)
        {
            if (count == 0)
            {
                return;
            }

            Console.Write(value + " ");  // вывод числа
            PrintLine(value, count - 1);  // рекурсивный вызов для вывода оставшихся чисел

            if (count == 1)
            {
                Console.WriteLine();  // переход на новую строку после завершения вывода строки
            }
        }

        static void PrintSequence(int n)
        {
            if (n == 0)
            {
                return;
            }

            PrintSequence(n - 1);  // рекурсивный вызов для предыдущего числа

            PrintLine(n, n);  // вывод строки для текущего числа
        }
        static void Main(string[] args)
        {
            Console.Write("Введите натуральное число n: ");
            int n = int.Parse(Console.ReadLine());

            PrintSequence(n);
        }
    }
}
