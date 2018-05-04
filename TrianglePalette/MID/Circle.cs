using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MID
{
    class Circle
    {
        public int radius;
        Graphics g;
        Brush b;
        public int x, y;

        Form1 f = new Form1();
        
        SolidBrush sol = new SolidBrush(Color.Black);
        

        public Circle(int radius, Brush b,  Graphics g, int x, int y)
        {
            this.radius = radius;
            this.b = b;
            this.g = g;
            this.x = x;
            this.y = y;
        }
        public Circle() { }

        public void Draw(Color c)
        {
            Font drawFont = new Font("Arial", radius / 4);
            string s = c.ToArgb().ToString();
            
            g.FillEllipse(b, x, y, radius, radius);
            g.DrawString(s, drawFont, sol, x+1, y+5);
        }

        public void Print()
        {

            g.FillEllipse(b, x, y, radius, radius);
        }
    }
}
