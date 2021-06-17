using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12_i_think
{
    public class Spectacol
    {
        public int _StartTime { get; set; }
        public int _FinishTime { get; set; }

        public Spectacol(int StartTime, int FinishTime)
        {
            _StartTime = StartTime;
            _FinishTime = FinishTime;
        }
    }
}
