using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaFinalMVC.Models
{
    public class MovieCelebrity
    {
        [Key]
        public int MovieCelebrityId { get; set; }

        [Display(Name = "MovieId")]
        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public virtual Movie Movie { get; set; }

        [Display(Name = "CelebrityId")]
        public int CelebrityId { get; set; }
        [ForeignKey("CelebrityId ")]
        public virtual Celebrity Celebrity { get; set; }
    }
}
