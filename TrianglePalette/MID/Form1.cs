using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace MID
{
    public partial class Form1 : Form
    {
        public Bitmap bmp;
        public Graphics g;

        public int number;
        public static int height, width;
        Color co1, co2, co3;
        public int cnt = 0;


        public Form1()
        {
            InitializeComponent();

            height = pictureBox1.Height;
            width = pictureBox1.Width;

        }

        public static List<Color> GetGradientColors(Color start, Color end, int steps, int firstStep, int lastStep)
        {
            var colorList = new List<Color>(height+width);
            if (steps <= 0 || firstStep < 0 || lastStep > steps - 1)
                return colorList;

            double aStep = (end.A - start.A) / steps;
            double rStep = (end.R - start.R) / steps;
            double gStep = (end.G - start.G) / steps;
            double bStep = (end.B - start.B) / steps;

            for (int i = firstStep; i < lastStep; i++)
            {
                var a = start.A + (int)(aStep * i);
                var r = start.R + (int)(rStep * i);
                var g = start.G + (int)(gStep * i);
                var b = start.B + (int)(bStep * i);
                colorList.Add(Color.FromArgb(a, r, g, b));
            }

            return colorList;
        }

        public static List<Color> GetGradientColors(Color start, Color end, int steps)
        {
            return GetGradientColors(start, end, steps, 0, steps - 1);
        }

        public void Draw()
        {
            Graphics g1 = pictureBox1.CreateGraphics();
            try
            {
                for (int i = 10; i < 300; i += number)
                {
                    
                    for (int j = 20; j <= i; j += number)
                    {
                        SolidBrush s;
                        if (i == number / 2)
                        {
                            s = new SolidBrush(GetGradientColors(co1, co3, 180)[j]);
                        }
                        s = new SolidBrush(GetGradientColors(co1, co2, 180)[j]);

                        Circle c = new Circle(number, s, g1, i, j);
                        c.Draw(GetGradientColors(co1, co2, 180)[j]);
                    }
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
            }
            
        }

        public void Paint()
        {
            Graphics g1 = pictureBox1.CreateGraphics();
            Color[] myCol = { co1, co2, co3 };
            ColorBlend blend = new ColorBlend();
            blend.Colors = myCol;
            float[] myPositions = {0.0f,.20f,.40f,.60f,.80f,1.0f};
            blend.Positions = myPositions;
            try
            {
                for (int i = 10; i < 300; i += number)
                {

                    for (int j = 20; j <= i; j += number)
                    {
                        Point p1 = new Point(i, j);
                        Point p2 = new Point(i, 120);
                        LinearGradientBrush br = new LinearGradientBrush(p1, p2, co1, co2);
                        br.InterpolationColors = blend;
                        //s = new SolidBrush(GetGradientColors(co1, co2, 180)[j]);

                        Circle c = new Circle(number, br, g1, i, j);
                        c.Print();
                    }
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            number = pictureBox1.Height / int.Parse(textBox4.Text);
            Draw();
            //Paint();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            co1 = colorDialog1.Color;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            colorDialog2.ShowDialog();
            co2 = colorDialog2.Color;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            colorDialog3.ShowDialog();
            co3 = colorDialog3.Color;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
