using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieMadness.Models
{
    public class ActorIndexViewModel
    {
        public int ActorId { get; set; }
        public string Name { get; set; }
        //list of movies where actor belongs
        public List<MovieViewModel> ActorMovies { get; set; }
    }
}