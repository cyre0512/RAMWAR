using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMadness.Model
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public string Post { get; set; }
        public DateTime DatePosted { get; set; }
        public int Rating { get; set; }
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
