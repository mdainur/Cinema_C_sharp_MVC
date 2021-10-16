using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaFinalMVC.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Premier Date")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Premiere { get; set; }
        [Display(Name = "Poster Url")]
        public string MoviePicture { get; set; }
        [Display(Name = "Trailer Url")]
        public string MovieTrailer { get; set; }
        [Required]
        [Display(Name = "Duration")]
        public string Duration { get; set; }
        [Display(Name = "Rating")]
        public double Rating { get; set; }
        [Required]
        [Display(Name = "Allowed Age")]
        [Range(1, int.MaxValue, ErrorMessage = "Allowed age must be greater than 0!")]
        public int age { get; set; }

        public List<MovieGenre> MovieGenres { get; set; }
        public List<MovieCelebrity> MovieCelebrities { get; set; }

    }
}


//[ForeignKey("CountryId")]
//public int CountryId { get; set; }
//public virtual Country Country { get; set; }
