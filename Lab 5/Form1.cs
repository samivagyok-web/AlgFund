using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PointF cg, eg;
        private void Form1_Load(object sender, EventArgs e)
        {
            MyGraphics.initGraph(pictureBox1);
            Engine.init();
            Engine.draw();

            cg = Engine.test.cg();

            MyGraphics.drawPoint(cg, Color.Red, Color.Black, 5);

            Poligon s = Engine.S(Engine.test);
           
            s.draw(MyGraphics.graphics);
            MyGraphics.refreshGraph();
        }
    }
}
