using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskTimer
{
    public partial class TaskControl : UserControl
    {
        public int sec=0, min=0, hour=0, onlySec = 0;
        public int h, m, s;
        public int start, stop;

        public TaskControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // start
        {
            Button b = (Button)sender;
            TaskControl t = (TaskControl)b.Parent;
            t.label1.Text = t.Name;
            t.label3.Text = Form1.time[0] + ":" + Form1.time[1] + ":" + Form1.time[2];
            
            t.timer1.Interval = 1000;
            t.timer1.Start();

            h = int.Parse(Form1.time[0]) * 3600;
            m = int.Parse(Form1.time[1]) * 60;
            s = int.Parse(Form1.time[2]);
            start = 0;
            stop = h + m + s;
        }

        public int getSpentTime()
        {
            return progressBar1.Value;
        }

        public string getName()
        {
            return Name;
        }

        private void button2_Click(object sender, EventArgs e) // reset
        {
            progressBar1.Value = 0;
            timer1.Start();
        }

        private void button3_Click(object sender, EventArgs e) // delete
        {
            //((Form)this.Container).Controls.Remove(this);
            //this.Parent.Controls.Remove(this);
            Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < progressBar1.Maximum) progressBar1.Value++;
            
            sec++;
            onlySec++;
            if (sec >= 60)
            {
                sec = 0;
                min++;
            }
            if (min >= 60)
            {
                min = 0;
                hour++;
            }

            label2.Text = hour + ":" + min + ":" + sec;
            
            progressBar1.Minimum = 0;
            progressBar1.Maximum = stop;
            progressBar1.Step = 1;

            /*if (onlySec == stop)
            {
                timer1.Stop();
            }*/
        }

        private void button4_Click(object sender, EventArgs e) // pause
        {
            timer1.Stop();
            progressBar1.Enabled = false;
        }
    }
}
