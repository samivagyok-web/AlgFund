using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curs_3
{
    class Program
    {
        static void Main(string[] args) 
        {
            Matrix A = new Matrix(@"..\..\matrix1.txt", true);
            foreach (string s in A.view())
                Console.WriteLine(s);


            Matrix B = new Matrix(@"..\..\matrix2.txt", true);
            foreach (string s in B.view())
                Console.WriteLine(s);

            Matrix C = A.Multiply(B);

            foreach (string s in C.view())
                Console.WriteLine(s);

            Matrix D = A.Add(B);

            foreach (string s in D.view())
                Console.WriteLine(s);
        }
    }
}
