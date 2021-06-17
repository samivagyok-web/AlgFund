using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prob2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] v1 = {2, 3, 3, 4, 4, 4, 3 };
            int[] v2 = { 1, 1, 1, 1, 1, 1, 1 };
            int[] v3 = { 1, 2, 3, 4, 5, 6, 6 };
            int[] v4 = { 1, 2, 3, 1, 2, 3, 1, 2, 3 };

            Dictionary<int, int> kv = GetPower(v1);
            int[] putere1 = SortDictValuesDesc(kv);

            Dictionary<int, int> kv2 = GetPower(v4);
            int[] putere2 = SortDictValuesDesc(kv2);

            PutereComparer(putere1, putere2);
        }

        private static int[] SortDictValuesDesc(Dictionary<int, int> kv)
        {
            int[] putere = kv.Values.ToArray();
            Array.Sort(putere);
            Array.Reverse(putere);

            return putere;
        }

        private static int PutereComparer(int[] v, int[] u)
        {
            int bound = Math.Min(v.Length, u.Length);

            for (int i = 0; i < bound; i++)
            {
                if (u[i] < v[i])
                    return -1;
                else if (u[i] > v[i])
                    return 1;
            }

            if (v.Length > u.Length)
                return -1;
            else if (v.Length < u.Length)
                return 1;
            else
                return 0;
        }

        private static Dictionary<int, int> GetPower(int[] v1)
        {
            Dictionary<int, int> kv = new Dictionary<int, int>();

            for (int i = 0; i < v1.Length; i++)
            {
                if (!kv.ContainsKey(v1[i]))
                    kv.Add(v1[i], 1);
                else
                    kv[v1[i]]++;
            }

            return kv;
        }
    }
}
