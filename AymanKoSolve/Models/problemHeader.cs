using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AymanKoSolve.Models
{
    public class problemHeader
    {

        [Key]
        public int problemid { get; set; }

        [Required, StringLength(200)]
        public string problemName { get; set; }

        [Required, StringLength(200)]
        public string problemDescription { get; set; }

        [Required, StringLength(200)]
        public string problemImage { get; set; }


        [Required, StringLength(200)]
        public string date { get; set; }
       
    


        public virtual ICollection<problemContent> problemContent { get; set; }


        public int problemTypeID { get; set; }
        public virtual problemType ProblemType { get; set; }

        public int problemSourceID { get; set; }
        public virtual problemSource problemSource { get; set; }

    }
}
