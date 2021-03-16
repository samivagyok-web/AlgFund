using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Curs1
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            //  int n = int.Parse(Console.ReadLine());
            //  int[] v = new int[n];
            //  for (int i = 0; i < n; i++)
            //      v[i] = rnd.Next(0, 100);
            //
            //  for (int i = 0; i < v.Length; i++)
            //      Console.Write($"{v[i]} ");
            //
            //  inserareSumaPrimelore(v);
            // vectorOneMilliElement();
            vectSortat();
        }

        private static void vectSortat()
        {
            int[] arr = new int[] { 1, 2 };

            int element = arr[0];
            int counter = 1;

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] == element)
                {
                    counter++;
                }
                else
                {
                    Console.Write($"{element} {counter} ");

                    counter = 1;
                    element = arr[i];
                }


                if (i == arr.Length - 1)
                    Console.Write($"{element} {counter} ");
            }
        }

        private static void vectorOneMilliElement()
        {
            #region puterea doi & perfect
            TextReader load = new StreamReader(@"..\..\Resurse\TextFile1.txt");
            string buffer;
            int tmp;
            int n = 0;
            
            while ((buffer = load.ReadLine()) != null)
            {
                string[] local = buffer.Split(' ');
                foreach (string s in local)
                {
                    // if (s != "0" && 524288 % int.Parse(s) == 0)
                    //     Console.WriteLine(s);

                    // if (sd(int.Parse(s)))
                    //     Console.WriteLine(s);

                }
            }
            #endregion
        }

        private static bool sd(int num)
        {
            int sum = 1;

            for (int i = 2; i*i <= num; i++)
            {
                if (num % i == 0)
                {
                    sum = sum + i;

                    if (num % num / i == 0 && num / i != i)
                        sum = sum + num / i;
                }
            }

            if (sum == num)
                return true;
            else
                return false;
        }

        private static bool palindromArray(int[] num)
        {
            for (int i = 0; i < num.Length / 2; i++)
            {
                if (num[i] != num[num.Length - i - 1])
                    Console.WriteLine(i); ;
            }

            return true;
        }

        private static void inserareSumaPrimelore(int[] num)
        {
            int k = 0;
            int[] r = new int[2 * num.Length];
            for (int i = 0; i < num.Length; i++)
            {
                r[k] = num[i];
                k++;
                if (isPrime(num[i]))
                {
                    r[k] = sumaCif(num[i]);
                    k++;
                }
            }
            Console.WriteLine();
            for (int i = 0; i < r.Length; i++)
                Console.Write($"{r[i]} ");
        }

        private static int sumaCif(int n)
        {
            int numNou = 0;

            while (n != 0)
            {
               int r = n % 10;
                numNou += r;
                n /= 10;
            }
            return numNou;
        }

        private static bool isPrime(int n)
        {
            if (n % 2 == 0)
                return false;

            if (n <= 5)
                return true;
            else
            {
                if (!((n + 1) % 6 == 0 || (n - 1) % 6 == 0))
                    return false;
                else
                {
                    for (int i = 3; i * i <= n; i += 2)
                    {
                        if (n % i == 0)
                            return false;
                    }
                }
            }
            return true;
        }
    }
}
