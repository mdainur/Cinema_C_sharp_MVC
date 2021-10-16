using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaFinalMVC.Models
{
    public class MovieGenre
    {
        [Key]
        public int MovieGenreId { get; set; }
        [Display(Name = "MovieId")]
        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public virtual Movie Movie { get; set; }

        [Display(Name = "GenreId ")]
        public int GenreId { get; set; }
        [ForeignKey("GenreId ")]
        public virtual Genre Genre { get; set; }
    }
}
