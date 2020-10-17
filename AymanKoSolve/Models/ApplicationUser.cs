using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AymanKoSolve.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Country { get; set; }

        public string PicPath { get; set; }

        public ICollection<ChatUser> chats { get; set; }
    }
}
