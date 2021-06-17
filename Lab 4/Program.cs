using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab_4
{
    class Program
    {
        static void Main(string[] args)
        {
            secProb();
        }

        private static void secProb()
        {
            Random rnd = new Random();
            int[,] mat1 = new int[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    mat1[i, j] = rnd.Next(0, 3);
                }
            }

            while (true)
            {
                int rowIndex = rnd.Next(0, 3);
                int coLIndex = rnd.Next(0, 3);


            }

        }

        #region Prima problema
        private static void primProb()
        {
            TextReader file = new StreamReader(@"TextFile1.txt");
            string[] dimensions = file.ReadLine().Split(' ');
            int line = int.Parse(dimensions[0]);
            int col = int.Parse(dimensions[1]);

            int[,] matrix = new int[line, col];

            for (int i = 0; i < line; i++)
            {
                string[] buffer = file.ReadLine().Split(' ');
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = int.Parse(buffer[j]);
                }
            }
            int[,] copyMat = new int[line, col];

            while (!primProbFinal(matrix))
            {
                for (int i = 0; i < line; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        Console.Write($"{matrix[i, j]} ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();

                for (int i = 0; i < line; i++)
                {
                    for (int j = 0; j < col; j++)
                        copyMat[i, j] = matrix[i, j];
                }

                for (int i = 0; i < line; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        if (primProbVeciniChecker(copyMat, i, j))
                        {
                            matrix[i, j] = 0;
                        }
                    }
                }
            }
            
        }

        private static bool primProbFinal(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 1)
                        return false;
                }
            }
            return true;
        }

        private static bool primProbVeciniChecker(int[,] matrix, int i, int j)
        {
            int rowLimit = matrix.GetLength(0) - 1;
            int colLimit = matrix.GetLength(1) - 1;
            int zeroCounter = 0;
            int oneCounter = 0;

            for (int x = Math.Max(0, i-1); x <= Math.Min(i+1, rowLimit); x++)
            {
                for (int y = Math.Max(0, j-1); y <= Math.Min(j + 1, colLimit); y++)
                {
                    if (x != i || y != j)
                    {
                        if (matrix[x, y] == 0)
                            zeroCounter++;
                        else
                            oneCounter++;
                    }
                }
            }
            return oneCounter <= zeroCounter;
        }

        #endregion
    }
}
