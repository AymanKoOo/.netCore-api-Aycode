using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AymanKoSolve.ModelViews.users
{
    public class AddUserModel
    {
        public string UserName { get; set; }

        [StringLength(256), Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Password { get; set; }

        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }

        public string Country { get; set; }
    }
}
