using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TaskTimer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        List<TaskControl> tasks = new List<TaskControl>();
        public static string[] time;

        private void Form1_Load(object sender, EventArgs e)
        {
            //timer1_Tick_1(sender, e);
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string label2 = textBox2.Text;
            time = label2.Split(':');
            tasks.Add(new TaskControl());
            tasks[tasks.Count - 1].Name = textBox1.Text;
            //this.Controls.Add(tasks[tasks.Count - 1]);
            panel1.Controls.Add(tasks[tasks.Count - 1]);
            if (tasks.Count > 1)
            {
                tasks[tasks.Count - 1].Top = tasks[tasks.Count - 2].Top + 60;
            }
            this.Refresh();
            //tasks[tasks.Count - 1].getTimer();
          //  this.panel1.Refresh();
            textBox1.Text = "";
            textBox2.Text = "";
            //changeChart(sender, e);
            
        }

        /*public void changeChart(object sender, EventArgs e)
        {
            //Color[] myPieColors = { Color.Red, Color.Black, Color.Blue, Color.Green, Color.Maroon };
            chart1.Series.Clear();
            chart1.Legends.Clear();

            string seriesname = "MySeriesName";
            chart1.Series.Add(seriesname);
            chart1.Series[seriesname].ChartType = SeriesChartType.Pie;

            foreach (var t in tasks)
            {
                chart1.Series[seriesname].Points.AddXY(t.Name, t.getSpentTime());
            }

            //DrawPieChart(myPiePercent, myPieColors, myPieGraphic, myPieLocation, myPieSize);

        }*/


        private void label1_Click(object sender, EventArgs e){}
        private void chart1_Click(object sender, EventArgs e){}

        private void timer1_Tick(object sender, EventArgs e)
        {
            chart1.Series["Series1"].Points.Clear();
            chart1.Series["Series1"].ChartType = SeriesChartType.Pie;
            foreach (TaskControl element in panel1.Controls)
            {
                if (element.getSpentTime() > 0)
                {
                    chart1.Series["Series1"].Points.AddXY(element.getName(), element.getSpentTime());
                }
            }
        }
    }
}
