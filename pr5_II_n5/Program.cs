using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prV_II_n5
{
    internal class Program
    {
        // Метод для нахождения суммы нечетных цифр числа
        static int SumOddDigits(int number)
        {
            int sum = 0;
            while (number > 0)
            {
                int digit = number % 10;
                if (digit % 2 != 0) // Если цифра нечетная
                {
                    sum += digit;
                }
                number /= 10;
            }
            return sum;
        }

        // Метод для проверки простого числа
        static bool IsPrime(int number)
        {
            if (number < 2)
            {
                return false;
            }
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            Console.Write("Введите значение a: ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Введите значение b: ");
            int b = int.Parse(Console.ReadLine());

            Console.Write("Введите значение C (для части b): ");
            int C = int.Parse(Console.ReadLine());

            Console.Write("Введите значение A (для части d): ");
            int A = int.Parse(Console.ReadLine());

            // a) Вывести для каждого целого числа на отрезке [a, b] сумму его нечетных цифр
            Console.WriteLine("a) Суммы нечетных цифр чисел от {0} до {1}:", a, b);
            for (int i = a; i <= b; i++)
            {
                Console.WriteLine($"Число: {i}, Сумма нечетных цифр: {SumOddDigits(i)}");
            }

            // b) Вывести только те числа, у которых сумма нечетных цифр равна заданному значению C
            Console.WriteLine($"\nb) Числа от {a} до {b}, у которых сумма нечетных цифр равна {C}:");
            for (int i = a; i <= b; i++)
            {
                if (SumOddDigits(i) == C)
                {
                    Console.WriteLine(i);
                }
            }

            // c) Вывести только те числа, у которых сумма нечетных цифр является простым числом
            Console.WriteLine($"\nc) Числа от {a} до {b}, у которых сумма нечетных цифр является простым числом:");
            for (int i = a; i <= b; i++)
            {
                int sumOdd = SumOddDigits(i);
                if (IsPrime(sumOdd))
                {
                    Console.WriteLine(i);
                }
            }

            // d) Для числа A вывести ближайшее следующее число, сумма нечетных цифр которого равна сумме нечетных цифр числа A
            int sumA = SumOddDigits(A);
            int nextNumber = A + 1;
            while (SumOddDigits(nextNumber) != sumA)
            {
                nextNumber++;
            }
            Console.WriteLine($"\nd) Ближайшее число к {A}, у которого сумма нечетных цифр равна сумме нечетных цифр числа {A}: {nextNumber}");
        }
    }
}
