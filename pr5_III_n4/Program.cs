using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr5_III_n4
{
    internal class Program
    {
        static int NOD(int a,  int b)
        {
            if (a == b)
            {
                return a;
            }
            else if (a > b)
            {
                return NOD(a - b, b);
            }
            else
            {
                return NOD(a, b - a);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число a: ");
            int a = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите число b: ");
            int b = int.Parse(Console.ReadLine());

            Console.WriteLine($"НОД({a}, {b}) = {NOD(a, b)}");
        }
    }
}
