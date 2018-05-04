using System.Drawing;
using System.Drawing.Drawing2D;
using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace GRA
{
    partial class Drawing : System.Windows.Forms.Form
    {
        public Drawing()
        {
            InitializeComponent();
        }
        bool colorCur = false;
        bool isDrag = false; 
        bool isRes = false;
        Point clicked = Point.Empty;

        bool doDel = false;

        Shape newShape;

        Shape sh = new Shape();

        public Color curColor = Color.White;

        public void _MouseMove(object sender, MouseEventArgs e){   
            Control cur = (Control)sender;

         
            if (isDrag)
            {
               cur.Left = e.X - clicked.X + cur.Left;
               cur.Top = e.Y - clicked.Y + cur.Top;
               sh.Type = Shape.ShapeType.NONE;
            }
            else if (isRes){
                if (cur.Cursor == Cursors.SizeNS) 
                {
                    cur.Height = e.Y;
                }
                else if (cur.Cursor == Cursors.SizeWE)
                {
                    cur.Width = e.X;
                }
                else if (cur.Cursor == Cursors.SizeNWSE)
                {
                    cur.Width = e.X;
                    cur.Height = e.Y;
                }
                else if (cur.Cursor == Cursors.SizeNESW)
                {
                    cur.Width = e.X;
                    cur.Height = e.Y;
                }
            }
            else {
                if (((e.X + 7) > cur.Width) && ((e.Y + 7) > cur.Height))
                {
                    cur.Cursor = Cursors.SizeNWSE;
                }
                /*else if (((e.X + 7) > 0) && ((e.Y + 7) > cur.Height))
                {
                    cur.Cursor = Cursors.SizeNESW;
                }
                else if (((e.X + 7) > cur.Width) && ((e.Y + 7) > 0))
                {
                    cur.Cursor = Cursors.SizeNESW;
                }*/
                else if (e.Y + 7 > cur.Height)
                {
                    cur.Cursor = Cursors.SizeNS;
                }
                else if (e.X + 7 > cur.Width)
                {
                    cur.Cursor = Cursors.SizeWE;
                }
                else
                {
                    cur.Cursor = Cursors.Arrow;
                }
            }
        }

        public void DrawShape(Point cur)
        {
            newShape = new Shape();
            newShape.Size = new Size(0, 0);
            newShape.ForeColor = Color.Black;
           
            newShape.Type = sh.Type;
           
            newShape.Location = cur;
            newShape.MouseDown += new MouseEventHandler(_MouseDown);
            newShape.MouseMove += new MouseEventHandler(_MouseMove);
            newShape.MouseUp += new MouseEventHandler(_MouseUp);
            newShape.BackColor = Color.Red;
            this.Controls.Add(newShape);
        }

        private void _MouseDown(object sender, MouseEventArgs e)
        {
            Control cur = (Control)sender;
            if (colorCur)
            {
                cur.ForeColor = colorDialog1.Color;
                //colorCur = false;
            }
            if (doDel)
            {
                cur.ForeColor = Color.White;
                doDel = false;
            }
                clicked = e.Location;
                DrawShape(e.Location);
                if ((e.X + 5) > cur.Width || (e.Y + 5) > cur.Height)
                {
                    isRes = true;
                }
                else isDrag = true;
        }
        private void _MouseUp(object sender,MouseEventArgs e) 
        {
            isDrag = false;
            isRes = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sh.Type = Shape.ShapeType.Rectangle;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sh.Type = Shape.ShapeType.Circle;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sh.Type = Shape.ShapeType.Triangle;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
         //   sh.pen.Width = trackBar1.Value;
            sh.ShapePen = new Pen(Color.Black, 4);
            System.Diagnostics.Debug.WriteLine(trackBar1.Value + " ");
        }

        private void Drawing_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                colorCur = true;
            }
            
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doDel = true;
        }

        private void Drawing_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                /*if (e.Location.X > clicked.X && e.Location.Y > clicked.Y) {
                    newShape.Width = e.Location.X - clicked.X;
                    newShape.Height = e.Location.Y - clicked.Y;
                }
                 * */
               newShape.Location = new Point(Math.Min(clicked.X, e.Location.X), Math.Min(clicked.Y, e.Location.Y));
                newShape.Size = new Size(Math.Abs(e.Location.X - clicked.X), Math.Abs(e.Location.Y - clicked.Y));
            }
        }

        private void Drawing_MouseDown(object sender, MouseEventArgs e)
        {
            clicked = e.Location;
            DrawShape(e.Location);
        }
    }
    public class Shape : UserControl {

        private ShapeType shape = ShapeType.Rectangle;
        private GraphicsPath path = null;
        public enum ShapeType
        {
            Rectangle,
            Circle,
            Triangle,
            NONE
        };
        public Point prevpoint;
        public static Pen pen = new Pen(Color.Black, 1);

        private void make()
        {
            path = new GraphicsPath();
            switch (shape)
            {
                case ShapeType.Rectangle:
                    path.AddRectangle(this.ClientRectangle);
                    break;
                case ShapeType.Circle:
                    path.AddEllipse(this.ClientRectangle);
                    break;
                case ShapeType.Triangle:
                    DrawTri();
                    break;
                case ShapeType.NONE:
                    break;
            }
            this.Region = new Region(path);
        }
        public ShapeType Type{
            get { return shape; }
            set {
                shape = value;
                make();
                 }
        }
        public Pen ShapePen {
        
        get {return pen;}
            set {pen = value; make();}
        }
        public void Draw(Graphics g, Point cur)
        {
            if (shape == ShapeType.Rectangle)
            {
                int w = Math.Abs(prevpoint.X - cur.X);
                int h = Math.Abs(prevpoint.Y - cur.Y);
                int minX = Math.Min(prevpoint.X, cur.X);
                int minY = Math.Min(prevpoint.Y, cur.Y);

                g.DrawRectangle(pen, minX, minY, w, h);
            }
            if (shape == ShapeType.Circle)
            {
                int w = Math.Abs(prevpoint.X - cur.X);
                int h = Math.Abs(prevpoint.Y - cur.Y);
                int minX = Math.Min(prevpoint.X, cur.X);
                int minY = Math.Min(prevpoint.Y, cur.Y);

                g.DrawEllipse(pen, minX, minY, w, h);
            }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e){
            if (path != null)  {
                    e.Graphics.FillPath(new SolidBrush(this.BackColor), path);
                    e.Graphics.DrawPath(pen, path);
                    System.Diagnostics.Debug.WriteLine(pen.Width + " drawing");
            }
        }
        protected override void OnResize(System.EventArgs e){
            make();
            this.Invalidate();//question 1
        }
        public void DrawTri()
        {
            Point[] p1 = 
                {
                new Point(this.Width/2,0),
                new Point(0, this.Height),
                new Point(this.Width, this.Height)
                };
            path.AddPolygon(p1);
        }
    }
}