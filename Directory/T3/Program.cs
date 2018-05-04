using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace T3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string s = Console.ReadLine();
                
                string source = @"C:\Users\User\Desktop";
                string[] f = Directory.GetFiles(source);

                string[] dirs = Directory.GetFiles(source+s);

                foreach (string dir in dirs)
                {
                    Console.WriteLine(dir);
                    
                }
                Console.ReadKey();
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("Sorry :) There is no such directory!");
                Console.WriteLine(e.Message);
                Console.ReadKey();
            } 
            catch (FileNotFoundException) 
            {
                Console.WriteLine("Sorry :) There is no such file!");
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Sorry :) You are not authorized!");
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
    }
}
