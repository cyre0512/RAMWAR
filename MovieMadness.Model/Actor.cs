using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMadness.Model
{
    public class Actor
    {
        [Key]
        public int ActorId { get; set; }
        public string Name { get; set; }
        public int MovieId { get; set; }
        public virtual List<Movie_Actors> MovieActors { get; set; }
    }
}
