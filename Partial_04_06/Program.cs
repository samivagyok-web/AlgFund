using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Partial_04_06
{
    class Program
    {
        static void Main(string[] args)
        {
            ex2();
        }
        #region ex1
        private static void ex1()
        {
            List<int> fibo = new List<int>();
            getFiboNums(ref fibo);
            int[] fiboArr = fibo.ToArray();

            TextReader f = new StreamReader(@"ex01.in");
            int numberOfValues = int.Parse(f.ReadLine());
            int[] values = new int[numberOfValues];
            string[] valuesFromFile = f.ReadLine().Split(' ');

            for (int i = 0; i < valuesFromFile.Length; i++)
                values[i] = int.Parse(valuesFromFile[i]);


            int[] resultArray = new int[numberOfValues];
            string textOut = "";
            for (int i = 0; i < resultArray.Length; i++)
            {
                resultArray[i] = determineNumber(values[i], fiboArr);
                textOut += resultArray[i];
            }
        }

        private static int determineNumber(int num, int[] fiboArr)
        {
            if (Array.BinarySearch(fiboArr, num) >= 0)
                return 0;

            return binarySearch(num, fiboArr);
        }

        private static int binarySearch(int num, int[] fiboArr)
        {
            if (num < fiboArr[0])
                return num;
            if (num > fiboArr[fiboArr.Length - 1])
                return num - fiboArr[fiboArr.Length - 1];

            int left = 0;
            int right = fiboArr.Length - 1;
            int mid;
            while (left <= right)
            {
                mid = left + (right - left) / 2;

                if (fiboArr[mid] > num)
                {
                    if (fiboArr[mid - 1] < num)
                        return Math.Min(Math.Abs(fiboArr[mid] - num), Math.Abs(fiboArr[mid - 1] - num));
                    else
                        right = mid - 1;
                }
                else if (fiboArr[mid] < num)
                {
                    if (fiboArr[mid + 1] > num)
                        return Math.Min(Math.Abs(fiboArr[mid] - num), Math.Abs(fiboArr[mid + 1] - num));
                    else
                        left = mid + 1;
                }
            }

            return -1;

        }

        private static int getDiff(int a, int b, int num)
        {
            int diffA = 0;
            int diffB = 0;

            diffA = Math.Abs(num - a);
            diffB = Math.Abs(num - a);

            if (diffA > diffB)
                return num - a;
            else
                return num - b;
        }

        private static void getFiboNums(ref List<int> fibo)
        {
            fibo.Add(0);
            fibo.Add(1);
            int a = 0;
            int b = 1;
            int c = 0;

            while (c < 999999999)
            {
                c = a + b;
                fibo.Add(c);
                a = b;
                b = c;
            }
        }
        #endregion

        #region ex2
        private static void ex2()
        {
            TextReader f = new StreamReader(@"ex02.in");
            string[] dim = f.ReadLine().Split(' ');
            int n = int.Parse(dim[0]);
            int m = int.Parse(dim[1]);
            int[,] matrix = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                string[] line = f.ReadLine().Split(' ');
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = int.Parse(line[j]);
                }
            }

            rec(matrix);
        }

        private static int[,] rec(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n == 1 && m == 1)
                return null;


            int matrix1N = n / 2;
            int matrix1M = m / 2;

            int[,] matrix1 = new int[matrix1N, matrix1M];
            int[] values = new int[matrix1N * matrix1M];
            int c = 0;

            for (int i = 0; i < n; i += 2)
            {
                for (int j = 0; j < m; j += 2)
                {
                    values[c++] = determinant(matrix, i, j);
                }
            }

            c = 0;
            for (int i = 0; i < n / 2; i++)
            {
                for (int j = 0; j < m / 2; j++)
                {
                    matrix1[i, j] = values[c];
                    c++;
                }
            }

            return rec(matrix1);
        }

        private static int determinant(int[,] matrix, int i, int j)
        {
            return matrix[i, j] * matrix[i + 1, j + 1] - matrix[i, j + 1] * matrix[i + 1, j];
        }

        private static void view(int[,] matrix)
        {

        }
        #endregion
    }
}
