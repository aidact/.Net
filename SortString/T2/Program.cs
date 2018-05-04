using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2
{
    class Program
    {
        

        static void Main(string[] args)
        {
            String s = "The cocoa is a nectar of the Gods";
            
            String[] sub = s.Split(new Char[] {' ', ','}) ;

            Array.Sort(sub);

            foreach (string c in sub)
            {
                Console.WriteLine(c);
                
            }
            Console.ReadKey();
        }
    }
}
