using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AymanKoSolve.Models
{
    public class ChatUser
    {
        public string UserId { get; set; }
        public ApplicationUser user { get; set; }

        public int ChatId { get; set; }
        public Chatt chat { get; set; }
    }
}
