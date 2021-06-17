using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Curs_6
{
    class Program
    {
        static void Main(string[] args)
        {
            TextReader file = new StreamReader(@"TextFile1.txt");
            string[] dimensions = file.ReadLine().Split(' ');
            int[,] matrix = new int[int.Parse(dimensions[0]), int.Parse(dimensions[1])];
            bool[,] boolmatrix = new bool[int.Parse(dimensions[0]), int.Parse(dimensions[1])];

            for (int i = 0; i < int.Parse(dimensions[0]); i++)
            {
                string[] buffer = file.ReadLine().Split(' ');
                for (int j = 0; j < int.Parse(dimensions[1]); j++)
                {
                    matrix[i, j] = int.Parse(buffer[j]);
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0 && !boolmatrix[i, j])
                    {
                        DFS2(boolmatrix, matrix, i, j);
                    }
                }
            }


       //    for (int i = 0; i < int.Parse(dimensions[0]); i++)
       //    {
       //        if (matrix[i, 0] == 1)
       //        {
       //            DFS1(boolmatrix, matrix, i, 0);
       //            Console.WriteLine();
       //        }                
       //    }
       //    if (ok)
       //        Console.WriteLine("LOL");
        }

        public static void DFS2 (bool[,] boolmatrix, int[,] matrix, int i, int j)
        {
            if ((i >= 0 && j >= 0 && i < matrix.GetLength(0) && j < matrix.GetLength(0) && !boolmatrix[i, j]))
            {
                boolmatrix[i, j] = true;
                DFS2(boolmatrix, matrix, i - 1, j);
                DFS2(boolmatrix, matrix, i, j + 1);
                DFS2(boolmatrix, matrix, i + 1, j);
                DFS2(boolmatrix, matrix, i, j - 1);
            }
        }

        public static void view (int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        
        public static void DFS1 (bool[,] boolmatrix, int[,] matrix, int i, int j)
        {
            if ((i >= 0 && j >= 0 && i < matrix.GetLength(0) && j < matrix.GetLength(0) && !boolmatrix[i, j] && matrix[i, j] == 1))
            {
                Console.WriteLine($"{i} - {j} - {matrix[i, j]}");

                boolmatrix[i, j] = true;
                DFS1(boolmatrix, matrix, i - 1, j);
                DFS1(boolmatrix, matrix, i, j + 1);
                DFS1(boolmatrix, matrix, i + 1, j);
                DFS1(boolmatrix, matrix, i, j - 1);
            }
        }
    }
}