using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab_12__i_think_
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            // probUnu();
            // probDoi();
            // probTrei();
        }

        private static void probTrei()
        {
            Dictionary<char, int> kv = new Dictionary<char, int>();
            TextReader f = new StreamReader(@"TextFile1.txt");

            string buffer = "";
            while((buffer = f.ReadLine()) != null)
            {
                for (int i = 0; i < buffer.Length; i++)
                {
                    if (kv.ContainsKey(buffer[i]))
                        kv[buffer[i]]++;
                    else
                        kv.Add(buffer[i], 1);
                }
            }

            string result = "";
            for (char i = '9'; i >= '0'; i--)
            {
                if (kv.ContainsKey(i))
                {
                    for (int j = 0; j < kv[i]; j++)
                        result += i;
                }
            }

            Console.WriteLine(result);
        }

        private static void probUnu()
        {
            int n = 6;
            int[,] a = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    a[i, j] = rnd.Next(10);
                    Console.Write(a[i,j] + " ");
                }
                Console.WriteLine();
            }
            int s = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i < j && i + j > n - 1 && j != n - 1)
                    {
                        s += a[i, j];
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine(s);
        }

        private static void probDoi()
        {
            TextReader f = new StreamReader(@"TextFile1.txt");
            int counter = 0;

            List<int> content = f.ReadToEnd().Split(' ').Select(p => int.Parse(p)).ToList();
            for (int i = content.Count - 1; i >= 0; i--)
            {
                if (content[i] % 2 == 1)
                {
                    Console.WriteLine(content[i]);
                    counter++;
                }

                if (counter == 2)
                    break;
            }           
        }
    }
}
