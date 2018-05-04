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
        public Drawing(){
            InitializeComponent();
        }
        bool isDrag = false; bool isRes = false;
        Point clicked = Point.Empty;
        public void _MouseMove(object sender, MouseEventArgs e){   
            Control cur = (Control)sender;
            if (isDrag){
                cur.Left = e.X - clicked.X + cur.Left;
                cur.Top = e.Y - clicked.Y + cur.Top;
            }
            else if (isRes){
                if (cur.Cursor == Cursors.SizeNS) { }// your code
                else if (cur.Cursor == Cursors.SizeNWSE)
                {
                    cur.Width = e.X;
                    cur.Height = e.Y;
                }
            }
            else {
                label1.Text = e.X + " " + e.Y;
                if (((e.X + 7) > cur.Width) &&((e.Y + 7) > cur.Height)) {
                    cur.Cursor = Cursors.SizeNWSE;
                }
                ///// your code
                else{
                    cur.Cursor = Cursors.Arrow;
                }
            }
        }
        void _MouseDown(object sender, MouseEventArgs e)
        {
            Control cur = (Control)sender;
                clicked = e.Location;
                if ((e.X + 5) > cur.Width || (e.Y + 5) > cur.Height){
                    isRes = true;
                }
                else isDrag = true;
        }
        private void _MouseUp(object sender,MouseEventArgs e) {
            Control cur = (Control)sender;
            isDrag = false;isRes = false;
        }
        private void pictureBox2_Click(object sender, EventArgs e) {
            shapik(Shape.ShapeType.Rectangle);
        }
        void shapik(Shape.ShapeType st) {
            Shape newShape = new Shape();
            newShape.Size = new Size(10, 10);
            newShape.ForeColor = Color.Black;
            newShape.Type = st;
            newShape.Location = new Point(100, 100);
            newShape.MouseDown += new MouseEventHandler(_MouseDown);
            newShape.MouseMove += new MouseEventHandler(_MouseMove);
            newShape.MouseUp += new MouseEventHandler(_MouseUp);
            newShape.BackColor = Color.Red;
            this.Controls.Add(newShape);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            shapik(Shape.ShapeType.Rectangle);
        }
    }
    public class Shape : UserControl {
        private ShapeType shape = ShapeType.Rectangle;
        private GraphicsPath path = null;
        public enum ShapeType{ Rectangle,Circle, Triangle }
        private void make(){
            path = new GraphicsPath();
            switch (shape){
                case ShapeType.Rectangle:
                    path.AddRectangle(this.ClientRectangle);
                    break;
                /// your code
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
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e){
            if (path != null)  {
                    e.Graphics.FillPath(new SolidBrush(this.BackColor), path);
                    e.Graphics.DrawPath(new Pen(this.ForeColor, 4), path);
            }
        }
        protected override void OnResize(System.EventArgs e){
            make();
            this.Invalidate();//question 1
        }
    }
}