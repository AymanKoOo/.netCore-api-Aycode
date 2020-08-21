using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AymanKoSolve.ModelViews.users
{
    public class editUserModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }

        [StringLength(256), Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool EmailConfirmed { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Country { get; set; }
    }
}
