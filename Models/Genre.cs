using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaFinalMVC.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name of the Genre")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        public List<MovieGenre> MovieGenres { get; set; }

    }
}
