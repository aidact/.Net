using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Task3
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

        static void Main(string[] args)
        {
            string s = Console.ReadLine();

            if (isPhoneMatch(s))
            {
                //String.Format("{0:(###) ###-####}", s);
                Console.WriteLine(String.Format("{0:(###) ###-####}", Convert.ToInt64(s)));
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Not a number!");
                Console.ReadKey();
            }
        }
    }
}
