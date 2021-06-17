using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curs_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write($"0 1");
            fibo(40, 0, 1);
            Console.WriteLine();
        }

        public static int factorial(int n)
        {
            if (n == 1)
                return 1;
            else
                return n * factorial(n - 1);
        }

        public static void fibo (int n, int a, int b)
        {
            if (n == 2)
                return;

            int c = a + b;
            a = b;
            b = c;
            Console.Write($" {c}");
            fibo(n - 1, a, b);
        }
    }
}
