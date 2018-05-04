using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quiz.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Date { get; set; }
        public double Rating { get; set; }
    }
}