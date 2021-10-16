using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaFinalMVC.Models
{
    public class Profession
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name of the Profession")]
        public string Name { get; set; }
    }
}
