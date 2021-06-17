using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ex03
{
    public partial class Form1 : Form
    {
        private List<PointF> blue = new List<PointF>();
        private List<PointF> green = new List<PointF>();
        private List<PointF> red = new List<PointF>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TextReader f = new StreamReader(@"testInput.txt");

            int numDePuncte = int.Parse(f.ReadLine());

            myGraphics.graph_init(pictureBox1);
            for (int i = 0; i < numDePuncte; i++)
            {
                string[] line = f.ReadLine().Split(' ');

                int x = int.Parse(line[0]);
                int y = int.Parse(line[1]);
                PointF p = new PointF(x, y);

                int primCounter = 0;

                if (primChecker(x)) primCounter++;
                if (primChecker(y)) primCounter++;

                if (primCounter == 2)
                {
                    myGraphics.drawPoint(p, Color.Red, Color.Red, 2);
                    red.Add(p);
                }
                else if (primCounter == 1)
                {
                    myGraphics.drawPoint(p, Color.Green, Color.Green, 2);
                    green.Add(p);
                }
                else
                {
                    myGraphics.drawPoint(p, Color.Blue, Color.Blue, 2);
                    blue.Add(p);
                }                
            }

            checkMinArea();

            saveToImage();
        }

        private void saveToImage()
        {

        }

        private void checkMinArea()
        {
            PointF[] minAreaPoints = new PointF[3];
            double minArea = 0;

            for (int i = 0; i < blue.Count; i++)
            {
                for (int j = 0; i < red.Count; i++)
                {
                    for (int z = 0; z < green.Count; z++)
                    {
                        double area = aria(blue[i], red[j], green[z]);

                        if (area > minArea)
                        {
                            minArea = area;
                            minAreaPoints[0] = blue[i];
                            minAreaPoints[1] = red[j];
                            minAreaPoints[2] = green[z];
                        }
                    }
                }
            }
            label1.Text = minAreaPoints[0].ToString() + " " + minAreaPoints[1].ToString() + " " + minAreaPoints[2].ToString();
        }

        private double distanta(PointF a, PointF b)
        {
            return Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
        }

        private double perimetru(PointF a, PointF b, PointF c)
        {
            return distanta(a, b) + distanta(b, c) + distanta(c, a);
        }

        private double aria(PointF a, PointF b, PointF c)
        {
            double p = perimetru(a, b, c) / 2;
            double B = distanta(a, c);
            double A = distanta(b, c);
            double C = distanta(a, b);
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }

        private bool primChecker(int n)
        {
            if (n % 2 == 0)
                return false;
            else
            {
                if (n <= 5)
                    return true;
                else
                {
                    if ((n - 1) % 6 != 0 && (n + 1) % 6 != 0)
                    {
                        return false;
                    }
                    else
                    {
                        for (int i = 3; i * i <= n; i++)
                        {
                            if (n % i == 0)
                                return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
