using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
{
    public partial class Form1 : Form
    {
        public bool t1 = false;
        public bool t2 = false;
        public bool t3 = false;
        public bool t4 = false;

        public Form1()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e) { }

        private void IsName()
        {
            string s = textBox1.Text;

                if (!Program.isNameMatch(s))
                    MessageBox.Show("Wrong name!");
                else MessageBox.Show("Keep going!");
        }

        private void Phone()
        {
            string s = textBox2.Text;

                if (!Program.isPhoneMatch(s))
                    MessageBox.Show("Wrong number!");
                else MessageBox.Show("Keep going!");
            
        }

        private void Email()
        {
            string s = textBox3.Text;

                if (!Program.isMailMatch(s))
                    MessageBox.Show("Wrong mail!");
                else MessageBox.Show("Keep going!");
        }
        private void ZIP()
        {
            string s = textBox4.Text;
            MessageBox.Show(s);

                if (!Program.isZipMatch(s))
                    MessageBox.Show("Wrong zip-code!");
                else MessageBox.Show("Successfully checked!");
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (e.KeyChar > 48 && e.KeyChar <53)
            {
                switch (e.KeyChar)
                {
                    case (char)49: t1 = true; break;
                    case (char)50: t2 = true; break;
                    case (char)51: t3 = true; break;
                    case (char)52: t4 = true; break;
                }
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IsName();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Phone();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Email();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ZIP();
        }
    }
}
