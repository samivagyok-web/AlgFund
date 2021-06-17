
using System.Drawing;

public static partial class Engine
{
    public static int resolution_width;
    public static int resolution_height;
    public static System.Drawing.Bitmap bitmap;
    public static System.Drawing.Graphics graphics;
    public static System.Drawing.Color backColor;
    public static System.Windows.Forms.PictureBox display;

    public static void graph_init(System.Windows.Forms.PictureBox T)
    {

        display = T;
        resolution_width = display.Width;
        resolution_height = display.Height;
        backColor = System.Drawing.Color.Gray;
        bitmap = new System.Drawing.Bitmap(resolution_width, resolution_height);
        graphics = System.Drawing.Graphics.FromImage(bitmap);
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

    public static PointF getRNDPointF()
    {
        System.Random rnd = new System.Random();
        return new PointF(rnd.Next(resolution_width), rnd.Next(resolution_height));
    }
}