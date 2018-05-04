using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Searcher
{
    class Search
    {
        Form1 f = new Form1();
        string[] directories = Directory.GetDirectories("C:\\");
        string[] files = Directory.GetFiles("C:\\", "*.dll");


        

        /*void DirSearch(string sDir)
        {
            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    foreach (string f in Directory.GetFiles(d, txtFile.Text))
                    {
                        lstFilesFound.Items.Add(f);
                    }
                    DirSearch(d);
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }*/
    }
}
