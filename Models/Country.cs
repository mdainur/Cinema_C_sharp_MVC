using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaFinalMVC.Models
{
    public class Country
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name of the Country")]
        public string Name { get; set; }
    }
}
