using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Task2
{
    class Program
    {
        public static Boolean isPhoneMatch(string s)
        {
            string number = @"^\(?\d{3}\)?[\s\-]?\d{3}\-?\d{4}$";

            /*Console.WriteLine(Regex.IsMatch(s, number));
            Console.ReadKey();*/

            if (Regex.IsMatch(s, number)) return true;
            else return false;
        }
        public static Boolean isZipMatch(string s)
        {
            string zip = @"^\d{5}([\-\s]?\d{4})*";

            if (Regex.IsMatch(s, zip)) return true;
            else return false;
        }
        public static Boolean isMailMatch(string s)
        {
            string mail = @"(^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$)";

            if (Regex.IsMatch(s, mail)) return true;
            else return false;
        }
        public static Boolean isNameMatch(string s)
        {
            string name = @"^[A-Z]*[a-z\-]+";
            if (Regex.IsMatch(s, name)) return true;
            else return false;
        }

        static void Main(string[] args)
        {
            /*string s = Console.ReadLine();

            isPhoneMatch(s);
            isZipMatch(s);*/
            Application.EnableVisualStyles();
            Application.DoEvents();
            Application.Run(new Form1());
        }
    }
}
