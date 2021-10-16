using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaFinalMVC.Models
{
    public class CelebrityProfession
    {
        [Key]
        public int CelebrityProfessionId { get; set; }
        [Display(Name = "CelebrityId")]
        public int CelebrityId { get; set; }
        [ForeignKey("CelebrityId")]
        public virtual Celebrity Celebrity { get; set; }

        [Display(Name = "ProfessionId")]
        public int ProfessionId { get; set; }
        [ForeignKey("ProfessionId")]
        public virtual Profession Profession { get; set; }
    }
}
