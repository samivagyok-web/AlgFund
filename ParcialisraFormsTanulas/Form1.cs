using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParcialisraFormsTanulas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myGraphics.graph_init(pictureBox1);
            myGraphics.graph_refresh();

            //     Poligon poli = new Poligon(4);
            //     poli.draw();

            myGraphics.drawLine(new PointF(60, 70), new PointF(120, 170));
        }
    }
}
