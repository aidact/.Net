using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace Searcher
{
    public partial class Form1 : Form
    {
        public static string t;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.DarkGray;
            this.TransparencyKey = Color.DarkGray;
            this.SetDesktopLocation(420, 200);
            listBox1.Text = "";
            t = textBox1.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.D1)
                this.Close();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private List<String> Search(Info info)
        {
            DirectoryInfo di = new DirectoryInfo(info.path);

            return Search(di, info);
        }

        private List<string> Search(DirectoryInfo di, Info info)
        {
            List<string> result = new List<String>();
            foreach (FileInfo file in di.GetFiles())
                if (info.matches(file))
                    result.Add(file.Name);
            foreach (DirectoryInfo dir in di.GetDirectories())
                foreach (string s in Search(dir, info))
                    result.Add(s);
            return result;
        }

        private List<String> SearchTime1(Info info)
        {
            string path = @"C:\Users\User\Desktop\3Subjects";
            DirectoryInfo di = new DirectoryInfo(path);

            return SearchTime(di, info);
        }

        private List<string> SearchTime(DirectoryInfo di, Info info)
        {
            List<string> result = new List<String>();
            foreach (FileInfo file in di.GetFiles())
                if (file.CreationTime >= dateTimePicker1.Value && file.CreationTime <= dateTimePicker2.Value)
                    result.Add(file.Name);
            foreach (DirectoryInfo dir in di.GetDirectories())
                foreach (string s in Search(dir, info))
                    result.Add(s);
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = false;

            listBox1.Items.Clear();
            string name = textBox1.Text;
            Info info = new Info(name);
            if (name.Length > 0)
            {
                info.path = textBox2.Text;
                foreach (string s in Search(info))
                {
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = listBox1.Items.Count * 100;
                    for (int i = 0; i < progressBar1.Maximum; i++)
                    {
                        progressBar1.Visible = true;
                        progressBar1.PerformStep();
                    }
                    progressBar1.Visible = false;
                        listBox1.Items.Add(s);
                }
            }
            if (checkBox1.Checked)
            {
                listBox1.Items.Clear();
                foreach (string s in SearchTime1(info))
                {
                    progressBar1.Visible = false;
                    listBox1.Items.Add(s);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBox2.Text = folderBrowserDialog1.SelectedPath;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
