using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AymanKoSolve.ModelViews
{
    public class Login
    {
        [StringLength(256), Required, DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Required]
        public string passowrd { get; set; }

        [Required]
        public bool RememberMe { get; set; }

    }
}
