using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr2_II_n18
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("Введите сторону a: ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("Введите сторону b: ");
            double b = double.Parse(Console.ReadLine());

            Console.Write("Введите сторону c: ");
            double c = double.Parse(Console.ReadLine());

            string result = (a * a + b * b == c * c || a * a + c * c == b * b || b * b + c * c == a * a) ? "Треугольник прямоугольный": "Треугольник не прямоугольный";
            
            Console.WriteLine(result);

        }
    }
}
