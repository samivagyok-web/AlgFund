using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex03
{
    public static class Helper
    {
        private static Random rnd = new Random();

        public static PointF[] getRNDpoints(int n)
        {
            PointF[] points = new PointF[n];

            var toReturn = points.Select(element =>
                 element = new PointF(rnd.Next(0, myGraphics.resolution_width),
                                        rnd.Next(0, myGraphics.resolution_height))).ToArray();

            return toReturn;
        }
    }
}
