using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaFinalMVC.Models
{
    public class Celebrity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Fullname of the Celebrity")]
        public string Fullname { get; set; }
        [Display(Name = "Birthdate of the Celebrity")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }
        [Display(Name = "Gender of the Celebrity")]
        public string Gender { get; set; }

        [ForeignKey("CountryId")]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        [Display(Name = "Picture Url of the Celebrity")]
        public string PictureUrl { get; set; }

        public List<MovieCelebrity> MovieCelebrities { get; set; }


    }
}
