using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace ex03
{
    public static class myGraphics
    {
        public static int resolution_width;
        public static int resolution_height;
        public static Bitmap bitmap;
        public static Graphics graphics;
        public static Color backColor;
        public static PictureBox display;

        public static void graph_init(System.Windows.Forms.PictureBox T)
        {
            display = T;
            resolution_width = display.Width;
            resolution_height = display.Height;
            backColor = Color.LightBlue;
            bitmap = new Bitmap(resolution_width, resolution_height);
            graphics = Graphics.FromImage(bitmap);
            graph_clear();
            graph_refresh();
        }

        public static void graph_clear()
        {
            graphics.Clear(backColor);
        }

        public static void graph_refresh()
        {
            display.Image = bitmap;
        }

        public static void drawPoint(PointF A, Color fillColor, Color drawColor, int radius)
        {
            Pen draw = new Pen(drawColor);
            SolidBrush fill = new SolidBrush(fillColor);
            graphics.FillEllipse(fill, A.X - radius, A.Y - radius, radius * 2 + 1, radius * 2 + 1);
            graphics.DrawEllipse(draw, A.X - radius, A.Y - radius, radius * 2 + 1, radius * 2 + 1);
        }

        public static void drawPolygon(Color drawColor, PointF[] points)
        {
            Pen draw = new Pen(drawColor);
            graphics.DrawPolygon(draw, points);
        }

        public static void drawLine(PointF A, PointF B)
        {
            graphics.DrawLine(new Pen(Color.Red), A, B);
        }
    }
}
