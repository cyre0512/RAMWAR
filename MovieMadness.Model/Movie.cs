using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMadness.Model
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public Genre Genre { get; set; }
        public ApplicationUser User { get; set; }
        //actor
        public virtual List<Movie_Actors> MovieActors { get; set; }
        //review
        public int ReviewId { get; set; }
        public virtual List<Review> Reviews { get; set; }
        public Rating Rating { get; set; }

        public string Thumbnail { get; set; }
    }
    public enum Genre
    {
        Action,
        Comedy,
        Documentary,
        Drama,
        Horror,
        Romance,
        SciFi,
        Thriller
    }

    public enum Rating 
    {
        G,
        PG,
        PG13,
        R
    }

}
