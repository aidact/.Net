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

namespace Levenstein
{
    public partial class Form1 : Form
    {
        StreamReader input = new StreamReader(@"C:\Users\User\Desktop\word.txt");
        string wo;
        public string znaki = ".!?";

        public Form1()
        {
            InitializeComponent();
            while ((wo = input.ReadLine()) != null)
            {
                words.Add(wo);
            }
            input.Close();
        }

        string text = "";
        public List<string> words = new List<string>();
        public List<string> answers = new List<string>();
        string word = "";
        int mouse;
        int[,] pd = null;

        public string FindMinDistance(string word)   // LEVENSTEIN ALGORYTHM
        {
            string s_comp, ans = "";
            int mini = 1000;
            int[,] dp = null;

            for (int k = 0; k < words.Count; k++)
            {
                s_comp = words[k];
                dp = new int[word.Length + 1, s_comp.Length + 1];
                for (int i = 0; i <= word.Length; i++)
                {
                    dp[i, 0] = i;
                }
                for (int j = 0; j <= s_comp.Length; j++)
                {
                    dp[0, j] = j;
                }

                for (int i = 1; i <= word.Length; i++)
                {
                    for (int j = 1; j <= s_comp.Length; j++)
                    {
                        if (word[i - 1] == s_comp[j - 1])
                        {
                            dp[i, j] = Math.Min(Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1), dp[i - 1, j - 1]);
                        }
                        else
                        {
                            dp[i, j] = Math.Min(Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1), dp[i - 1, j - 1] + 2);
                        }
                    }
                }

                if (dp[word.Length, s_comp.Length] <= mini)
                {
                    mini = dp[word.Length, s_comp.Length];
                    ans = s_comp;
                    pd = dp;
                    if (mini <= 3)
                    {
                        answers.Add(ans);
                    }
                }
            }
            return ans;
        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e) {}

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (text == richTextBox1.Text) return;
            text = richTextBox1.Text;
            int n = text.Length;
            if (n > 0 && !Char.IsLetter(text[n - 1]))
            {
                for (int i = n - 2; i >= 0; i--)
                {
                    if (i == 0) { word = text.Substring(i, n - i - 1); break; }
                    if (!Char.IsLetter(text[i])) { word = text.Substring(i + 1, n - i - 2); break; }
                }

                mouse = richTextBox1.SelectionStart;

                if (words.Contains(word))     // WORD EXIST IN DICTIONARY
                {
                    return;
                }
                //else ChangeColor(false);

                
                if (autoCor.Checked)                 // AUTO CORRECTOR
                {
                    text = replace(text, word, FindMinDistance(word), mouse - 1);
                    //ChangeColor(true);
                }
                ChangeColor(false);

                if (!autoCor.Checked)
                {
                    //label1.Text = word+ " "+cnt++;

                    textBox1.Text = FindMinDistance(word);
                    ChangeColor(false);

                    listBox1.Items.Clear();
                    foreach (string s in answers)
                    {
                        listBox1.Items.Add(s);
                    }
                }

                richTextBox1.Text = text;
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
            }
        }

        private void button1_Click(object sender, EventArgs e) // IGNORE INCORRECT WORD
        {

            richTextBox1.ForeColor = Color.Black;

        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e) // CHOOSE FROM DICTIONARY
        {
            mouse = richTextBox1.SelectionStart;
            if (text == richTextBox1.Text) return;
            text = richTextBox1.Text;
            int n = text.Length;
            if (n > 0 && !Char.IsLetter(text[n - 1]))
            {
                for (int i = n - 2; i >= 0; i--)
                {
                    if (i == 0) { word = text.Substring(i, n - i - 1); break; }
                    if (!Char.IsLetter(text[i])) { word = text.Substring(i + 1, n - i - 2); break; }

                }

                text = replace(text, word, listBox1.SelectedItem.ToString(), mouse-1);
                richTextBox1.Text = text;
                //ChangeColor(true);
               
                System.Diagnostics.Debug.Write(text);
                richTextBox1.Text = text;
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
            }
        }
        public string  replace(string tex, string wd, string ans, int n) {
            string s = tex.Remove(n - wd.Length, wd.Length);
            tex = s.Insert(n - wd.Length, ans);
            return tex;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            text = text.Replace(word, textBox1.Text);
        }

        private void listBox1_DoubleClick(object sender, EventArgs e) // CHOOSE CORRECT WORD
        {
            //text = text.Replace(word, listBox1.SelectedItem.ToString());
            text = replace(text, word, listBox1.SelectedItem.ToString(), mouse - 1);
            richTextBox1.Text = text;
            System.Diagnostics.Debug.Write(text);
            ChangeColor(true);

        }

        private void button2_Click(object sender, EventArgs e) // ADD TO DICTIONARY
        {
            listBox1.Items.Add(word);
        }

        private void ChangeColor(bool cor)
        {
            Random rand = new Random();
            if (cor == false)
            {
                //MessageBox.Show("false");
                int st = richTextBox1.SelectionStart;
                int end = word.Length;
                richTextBox1.SelectionStart = Math.Max(0, st - end - 1);
                richTextBox1.SelectionLength = end;
                richTextBox1.SelectionColor = Color.Red;
                richTextBox1.SelectionStart = st;
                richTextBox1.SelectionLength = 0;
           //     richTextBox1.SelectionColor = Color.Black;
            }
            else if(cor == true)
            {
                //MessageBox.Show("tru");
                int st = richTextBox1.SelectionStart;
                int end = word.Length;
                richTextBox1.SelectionStart = Math.Max(0,st - end - 1);
                
                richTextBox1.SelectionColor = Color.Black;
                //richTextBox1.SelectionLength = 0;
                richTextBox1.SelectionStart = st;
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e) {}

        private void richTextBox1_MouseClick(object sender, MouseEventArgs e) 
        {
            //  if(e.Button == MouseButtons.Right)
            // richTextBox1.SelectionStart 
        }
        private void label1_Click(object sender, EventArgs e){}
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e){}

        private void label3_Click(object sender, EventArgs e)
        {
            //label3.Text = FindMinDistance("japana");
        }
    }
}
