using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Levenstein
{
    class Program
    {

        


        /*public static int Distance(string original, string modified) 
        {
            int origLen = original.Length;
            int diffLen = modified.Length;

            var matrix = new int[origLen + 1, diffLen + 1];

            for (int i = 0; i <= origLen; i++)
            {
                matrix[i, 0] = i;
            }

            for (int j = 0; j <= diffLen; j++)
            {
                matrix[0, j] = j;
            }
            

            for (int i = 1; i <= origLen; i++)
            {
                for (int j = 1; j <= diffLen; j++)
                {
                    int cost;
                    if (modified[j - 1] == original[i - 1]) // same letter
                    {
                        cost = 0; 
                    }
                    else
                    {
                        cost = 2; // substitution
                    }

                    var vals = new int[] {matrix[i - 1, j] + 1, matrix[i, j - 1] + 1, matrix[i - 1, j - 1] + cost};

                    matrix[i, j] = vals.Min();

                    if (i > 1 && j > 1 && original[i - 1] == modified[j - 2] && original[i - 2] == modified[j - 1])
                    {
                        matrix[i, j] = Math.Min(matrix[i, j], matrix[i - 2, j - 2] + cost);
                    }

                }
            }
            return matrix[origLen, diffLen];
        }*/


        /*public static string CorrectWord(string incor)
        {
            Form1 f = new Form1();
            int min = 10000000;
            string cor = string.Empty;
            int d = 0;
            foreach(string w in f.words){
               d = f.FindMinDistance(incor);
                    if (d < min)
                    {
                        min = d;
                        cor = w;
                    }
            }
            return cor;
        }

        public static List<string> CorrectWordList(string incor)
        {
            Form1 f = new Form1();
            List<string> li  = new List<string>();

            foreach(string w in f.words){
                if(Distance(incor, w) < 2)
                    li.Add(w);
            }
            return li;
        }*/


        static void Main(string[] args)
        {
            Application.Run(new Form1());
        }
    }
}
