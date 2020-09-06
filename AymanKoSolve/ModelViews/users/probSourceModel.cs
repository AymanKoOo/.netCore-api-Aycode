using AymanKoSolve.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AymanKoSolve.ModelViews.users
{
    public class probSourceModel
    {
       
            [Required, StringLength(200)]
            public string sourceName { get; set; }

            [Required, StringLength(200)]
            public string problemSourceImage { get; set; }


            [Required, StringLength(200)]
            public string sourceDescription { get; set; }

            public virtual ICollection<problemHeader> problemHeader { get; set; }

    }
}

