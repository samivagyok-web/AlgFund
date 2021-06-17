using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab6
{
    public static class MainEngine
    {
        static List<Unit> army1 = new List<Unit>();
        static List<Unit> army2 = new List<Unit>();

        public static void init_demo()
        {
            Unit a = new Unit(default_units.Soldier);
            Unit b = new Unit(10, 10, 100, 10, 5);
            b.setColor(Color.AntiqueWhite, Color.Black);
            b.mapLocation = Engine.getRNDPointF();
            army1.Add(b);
        }

        public static void init_session()
        {
            army1 = new List<Unit>();
            army2 = new List<Unit>();
        }

        public static void drawMap()
        {
            Engine.graph_clear();
            foreach (Unit u in army1)
                u.draw(Engine.graphics);
            Engine.graph_refresh();
        }
    }
}