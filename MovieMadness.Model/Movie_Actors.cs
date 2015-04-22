using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMadness.Model
{
    public class Movie_Actors
    {
        [Key]
        public int MovieActorsId { get; set; }
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        public int ActorId { get; set; }
        public virtual Actor Actor { get; set; }
    }
}
