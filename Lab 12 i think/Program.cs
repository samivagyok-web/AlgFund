using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12_i_think
{
    class Program
    {
        static void Main(string[] args)
        {
         //   trei();
            spectacol();
        }

        private static void spectacol()
        {
            TextReader file = new StreamReader("TextFile2.txt");
            int numOfPairs = int.Parse(file.ReadLine());
            Spectacol[] spectacole = new Spectacol[numOfPairs];

            for (int i = 0; i < 5; i++)
            {
                string[] line = file.ReadLine().Split(' ');
                spectacole[i] = new Spectacol(int.Parse(line[0]), int.Parse(line[1]));
            }
            spectacole = spectacole.OrderBy(p => p._FinishTime).ToArray();

            int maxTime = spectacole[0]._FinishTime;
            Console.WriteLine($"{spectacole[0]._StartTime} - {spectacole[0]._FinishTime}");

            foreach (var spectacol in spectacole)
            {                                               
                if (maxTime <= spectacol._StartTime)
                {
                    Console.WriteLine($"{spectacol._StartTime} - {spectacol._FinishTime}");
                    maxTime = spectacol._FinishTime;
                }
            }
        }

        private static void trei()
        {
            TextReader file = new StreamReader("TextFile1.txt");
            string[] content = file.ReadToEnd().Split(' ');
            int primNum = int.Parse(content[0]);

            // 1
            int counter = 0;
            for (int i = 1; i < content.Length; i++)
            {
                if (int.Parse(content[i]) < primNum)
                    counter++;
            }
            Console.WriteLine(counter + 1);

            // 2
            Console.WriteLine(content.Where(p => int.Parse(p) < primNum).Count() + 1);
        }
    }
}
