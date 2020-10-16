using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AymanKoSolve.Models
{
    public class problemContent
    {
        [Key]
        public int contentProblemid { get; set; }

        [Required, StringLength(200)]
        public string contentProblemName { get; set; }


        [Required, StringLength(200)]
        public string contentProblemDescription { get; set; }


        [Required, StringLength(200)]
        public string contentproblemImage { get; set; }

        [Required]
        public string code { get; set; }

        [Required, StringLength(200)]
        public string date { get; set; }


        public int problemHeaderID { get; set; }

        public virtual problemHeader problemHeader { get; set; }

    }
}
