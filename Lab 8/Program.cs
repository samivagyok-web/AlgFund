using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    class Program
    {
        static int[] k = new int[9];
        static int m = 0;

        static void Main(string[] args)
        {
        //    EightQueen();
        }



        static void EightQueen()
        {
            back(1);
        }

        static void result(int m)
        {
            Console.WriteLine($"Result {m}: ");
            for (int i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    if (k[i] == j)
                        Console.Write("K ");
                    else
                        Console.Write("* ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static bool notAttacking(int i)
        {
            for (int j = 1; j <= i-1; j++)
            {
                if ((k[i] == k[j]) || ((i - j) == Math.Abs(k[i] - k[j])))
                    return false;
            }

            return true;
        }

        static void back (int i)
        {
            for (int j = 1; j <= 8; j++)
            {
                k[i] = j;
                if (notAttacking(i))
                {
                    if (i < 8)
                        back(i + 1);
                    else
                    {
                        m++;
                        result(m);
                    }
                }
            }
        }
    }
}
