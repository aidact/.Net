using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Quiz.Models;
using System.Text.RegularExpressions;

namespace Quiz.Controllers
{
    public class MovieController : Controller
    {
        StreamReader sr = new StreamReader(@"C:\Users\User\Desktop\listofmovies.txt");
        public static List<Models.Movie> list = new List<Models.Movie>();

        Random rand1 = new Random();
        
        // GET: Movie
        public ActionResult Random()
        {
            String st = sr.ReadToEnd();
            //string name = @"([A-Z])(\s?[A-Z]?)*";
            
            string name2 = @"\d\.\d((.*))\(";

            //string rate = @"\d\.\d";
            string date = @"\((\d{4})\)";
            sr.Close();

            MatchCollection match1 = Regex.Matches(st, name2);
            MatchCollection match3 = Regex.Matches(st, date);

            for (int i = 1; i < 1001; i++)
            {
                list.Add(new Movie() { Id = i });
            }

            foreach (Match m in match1)
            {
                list.Add(new Movie() { Title = m.Groups[1].Value });
            }
            foreach (Match m in match3)
            {
                list.Add(new Movie() { Date = int.Parse(m.Groups[1].Value) });
            }

            int f = rand1.Next(1, 1000);
            int s = rand1.Next(1, 1000);
            int t = rand1.Next(1, 1000);


            //var r = list.OrderBy(n => n.Date).Select(n => n).ToList();
            var res = list.OrderBy(n => n.Title).Select(n => n).Where(n => n.Id == f || n.Id == s || n.Id == t).ToList();
            
            return View(res);
        }
    }
}