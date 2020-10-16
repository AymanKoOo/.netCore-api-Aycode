using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AymanKoSolve.Models
{
    public class problemSource
    {
      
        [Key]
        public int problemSourceID { get; set; }

        [Required,StringLength(200)]
        public string sourceName { get; set; }

        [Required, StringLength(200)]
        public string problemSourceImage { get; set; }


        [Required, StringLength(200)]
        public string sourceDescription { get; set; }

        public virtual ICollection<problemHeader> problemHeader { get; set; }

    }
}
