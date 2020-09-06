using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AymanKoSolve.Models
{
    public class problemType
    {
        [Key]
        public int problemTypeID { get; set; }

        [Required, StringLength(200)]
        public string problemTypee { get; set; }

        [Required, StringLength(200)]
        public string problemTypeImage { get; set; }


        [Required, StringLength(200)]
        public string problemTDescription { get; set; }

        public virtual ICollection<problemHeader> problemHeader { get; set; }

    }
}
