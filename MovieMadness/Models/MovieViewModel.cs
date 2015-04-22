using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieMadness.Models
{
    //Similar to Movie class but w/o the virtual properties
    public class MovieViewModel
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Rating { get; set; }
    }
}