using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab_5
{
    public class Poligon
    {
        public PointF[] points;

        public Poligon(PointF[] points)
        {
            this.points = new PointF[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                this.points[i] = new PointF(points[i].X, points[i].Y);
            }
        }



        public Poligon(int no_of_points)
        {
            points = new PointF[no_of_points];

            for (int i = 0; i < no_of_points; i++)
                points[i] = Engine.getRNDPoint();
        }

        public void draw(Graphics grp)
        {
            grp.DrawPolygon(Pens.Black, points);
        }

        public PointF cg ()
        {
            float X = 0;
            float Y = 0;

            for (int i = 0; i < points.Length; i++)
            {
                X += points[i].X;
                Y += points[i].Y;
            }

            return new PointF(X / points.Length, Y / points.Length);
        }
    }
}
