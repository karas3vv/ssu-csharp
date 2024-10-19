using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr3_IV_n18
{
    internal class Program
    {
        static void Main()
        {
            for (int i = 100; i <= 999; i++) {
                int a = i / 100;
                int b = i / 10 % 10;
                int c = i % 10;

                if (a == b || a == c || b == c)
                {
                    Console.WriteLine(i);
                }    
            }
        }
    }
}
