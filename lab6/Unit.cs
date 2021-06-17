using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    public enum default_units
    {
        [unit_attr(10, 10, 100, 10, 5)]
        Soldier,
        [unit_attr(20, 5, 100, 50, 5)]
        Archer,
        [unit_attr(20, 15, 500, 20, 20)]
        Orc
    }
    
    public class unit_attr : Attribute
    {
        int Attack, Defense, HP, Firepower, Armor;

        public unit_attr(int Attack, int Defense, int HP, int FP, int Armor)
        {
            this.Attack = Attack;
            // TODO rest
        }
    }

    class Unit
    {
        string name;
        int Attack, Defense, HP, Firepower, Armor;
        Color fillColor, drawColor;
        public PointF mapLocation;
        public Unit(default_units T)
        {
            
        }

        public Unit(int Attack, int Defense, int HP, int FP, int Armor)
        {
            this.Attack = Attack;
            this.Defense = Defense;
            this.HP = HP;
            this.Firepower = FP;
            this.Armor = Armor;

            this.name = "";
        }

        
        public void setName(string name)
        {
            this.name = name;
        }

        public void setColor(Color fillColor, Color draw)
        {
            this.fillColor = fillColor;
            this.drawColor = drawColor;
        }

        public void setMapLocation(PointF mapLocation)
        {
            this.mapLocation = mapLocation;
        }

        public void draw(Graphics toDraw)
        {
            int size = 7 + HP/50;
            toDraw.FillEllipse(new SolidBrush(fillColor), mapLocation.X - size, mapLocation.Y - size, size * 2 + 1, size * 2 + 1);
            toDraw.DrawEllipse(new Pen(drawColor), mapLocation.X - size, mapLocation.Y - size, size * 2 + 1, size * 2 + 1);
            if (name != "")
                toDraw.DrawString(name, new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.Black), mapLocation);
        }
    }
}