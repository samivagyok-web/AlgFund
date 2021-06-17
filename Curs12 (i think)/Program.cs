using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curs12__i_think_
{
    class Program
    {
        static void Main(string[] args)
        {
            problemaUnu();
        }

        public static void problemaUnu()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            
            int d = 2;
            int max = 0;
            int maxNum = 0;

            for (int i = 2; i <= n; i++)
            {
                int counter = 0;
                int copyI = i;

                while (i != 1)
                {
                    if (i % d == 0)
                    {
                        i = i / d;
                        counter++;
                    }
                    else
                        d++;

                    if (counter > max)
                    {
                        max = counter;
                        maxNum = copyI;
                    }
                }
            }

            Console.WriteLine(maxNum);
        }        
    }
}
