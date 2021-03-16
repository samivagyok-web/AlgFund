using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curs2
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            probFive();
        }

        private static void firstProb()
        {
            int n = 5000;
            int[] v = new int[n];
            int[] freq = new int[1000];
            for (int i = 0; i < n; i++)
            {
                v[i] = rnd.Next(-10000, 10001);
                if (v[i] > 99 && v[i] < 1000)
                    freq[v[i]]++;
            }

            int counter = 3;
            for (int i = 999; i >= 100; i--)
            {
                if (freq[i] == 0)
                {
                    Console.Write($"{i} ");
                    counter--;

                    if (counter == 0)
                        break;
                }
            }
        }

        private static void secProb()
        {
            int n, m;
            Console.Write($"n = ");
            n = int.Parse(Console.ReadLine());
            Console.Write($"m = ");
            m = int.Parse(Console.ReadLine());

            HashSet<int> prim = new HashSet<int>();
            HashSet<int> sec = new HashSet<int>();

            while (n > 0)
            {
                int r = n % 10;
                if (!prim.Contains(r))
                    prim.Add(r);

                n /= 10;
            }

            while (m > 0)
            {
                int r = m % 10;
                if (!sec.Contains(r))
                    sec.Add(r);

                m /= 10;
            }

            for (int i = 0; i < prim.Count; i++)
            {
                if (sec.Contains(prim.ElementAt(i)))
                    Console.Write(prim.ElementAt(i));
            }
        }

        private static void probThree()
        {
            int n;
            Console.Write("n = ");
            n = int.Parse(Console.ReadLine());
            List<int> a = new List<int>();

            while (n > 0)
            {
                a.Add(n % 10);
                n /= 10;
            }

            a.Sort();
            int celMaiMare = 0;

            for (int j = a.Count - 1; j >= 0; j--)
            {
                celMaiMare = celMaiMare * 10 + a[j];
            }
            Console.WriteLine($"Cel mai mare: {celMaiMare}");

            int i = 0;
            if (a[i] == 0)
            {
                while (i < a.Count - 1 && a[i + 1] == 0)
                    i++;

                int aux = a[i + 1];
                a[i + 1] = 0;
                a[0] = aux;
            }

            int celMaiMic = 0;

            for (int j = 0; j < a.Count; j++)
            {
                celMaiMic = celMaiMic * 10 + a[j];
            }
            Console.WriteLine($"Cel mai mic: {celMaiMic}");
        }

        private static void probFour()
        {
            int n = int.Parse(Console.ReadLine());
            int[] v = new int[1001];
            int[] freq = new int[1001];

            for (int i = 0; i < n; i++)
            {
                v[i] = rnd.Next(0, 1000);
                freq[v[i]]++;
            }

            for (int i = 0; i < freq.Length; i++)
            {
                if (freq[i] > 0)
                {
                    for (int j = 0; j < freq[i]; j++)
                    {
                        Console.Write($"{i} ");
                    }
                }
            }
        }

        private static void probFive()
        {
            int n = 20;
            int[] v = new int[n];

            for (int i = 0; i < n; i++)
                v[i] = rnd.Next(100);



        }

        public static bool isPrime(int n)
        {
            if (n < 2)
                return false;
            if (n % 2 == 0)
                return false;
            if (n <= 5)
                return true;

            for (int i = 3; i*i <= n; i =+ 2)
            {
                if (n % i == 0)
                    return false;
            }

            return true;
        }

    }
}
