using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AymanKoSolve.ModelViews.problem
{
    public class addProblemSource
    {
        [Required]
        public int problemSourceID { get; set; }
     
        [Required, StringLength(200)]
        public string sourceName { get; set; }

        [Required, StringLength(200)]
        public string problemSourceImage { get; set; }


        [Required, StringLength(200)]
        public string sourceDescription { get; set; }

    }
}
