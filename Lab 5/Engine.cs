using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    public static partial class Engine
    {
        public static Random rnd = new Random();
        public static PointF getRNDPoint()
        {
            float X = rnd.Next(MyGraphics.resx);
            float Y = rnd.Next(MyGraphics.resy);
            return new PointF(X, Y);
        }



        public static Poligon test;
        public static void init()
        {
            test = new Poligon(10);
            test.drawColor = Color.Black;
        }

        public static void draw()
        {
            test.draw(MyGraphics.graphics);
            MyGraphics.refreshGraph();
        }

        public static Poligon S(Poligon P)
        {
            PointF[] s = new PointF[P.points.Length];
            for (int i = 0; i < P.points.Length - 1; i++)
            {
                float X = P.points[i].X + P.points[i + 1].X;
                float Y = P.points[i].Y + P.points[i + 1].Y;
                s[i] = new PointF(X, Y);
            }

            return new Poligon(s);
        }
    }
}
