using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Examen
{
    class Program
    {
        static void Main(string[] args)
        {
            prob1();
        }

        private static void prob1()
        {
            TextReader file = new StreamReader(@"data01.in");

            int[] v1 = GetArrays(file);
            int[] v2 = GetArrays(file);

            int[] merged = Interclasare(v1, v2);

            string toFile = "";

            for (int i = 0; i < merged.Length; i++)
            {
                toFile += merged[i] + " ";
            }
            //   CreateAndWriteFile(@"C:\Users\Sami\source\repos\AlgFund\Examen\data1.out", toFile);
            string path = Path.GetFullPath("data01.in");
            Console.WriteLine(path);
            //CreateAndWriteFile(@"\..\..\..\data1.out", toFile);

        }

        private static int[] Interclasare(int[] v1, int[] v2)
        {
            int[] mergedArr = new int[v1.Length + v2.Length];

            int i = 0, j = 0, z = 0;

            while (i < v1.Length && j < v2.Length)
            {
                if (v1[i] > v2[j])
                {
                    mergedArr[z] = v2[j];
                    j++;
                    z++;
                }
                else if (v1[i] < v2[j])
                {
                    mergedArr[z] = v1[i];
                    i++;
                    z++;
                }
                else
                {
                    mergedArr[z] = v1[i];
                    mergedArr[z + 1] = v2[j];
                    z += 2;
                    i++;
                    j++;
                }
            }

            while (i < v1.Length)
            {
                mergedArr[z] = v1[i];
                i++;
                z++;
            }

            while (j < v2.Length)
            {
                mergedArr[z] = v2[j];
                j++;
                z++;
            }

            return mergedArr;
        }

        private static int[] GetArrays(TextReader file)
        {
            file.ReadLine();
            string[] arr = file.ReadLine().Split(' ');

            int counter = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (IsPar(int.Parse(arr[i])))
                    counter++;
            }

            int[] toReturn = new int[counter];

            int j = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (IsPar(int.Parse(arr[i])))
                {
                    toReturn[j] = int.Parse(arr[i]);
                    j++;
                }       
            }

            return toReturn;
        }

        private static bool IsPar(int n) => n % 2 == 0; 

        #region Helpers
        public static void CreateAndWriteFile(string path, string content) => File.WriteAllText(path, content);

        public static void ViewArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i]} ");

            Console.WriteLine();
        }

        public static void View2DArray(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    Console.Write($"{arr[i,j]} ");
                }
                Console.WriteLine();
            }
        }
        #endregion
    }
}
