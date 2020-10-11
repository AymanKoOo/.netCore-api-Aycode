using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AymanKoSolve.Models
{
    public class Chatt
    {

        public Chatt()
        {
            Message = new List<Message>();
            Users = new List<ChatUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Message> Message { get; set; }
        public ICollection<ChatUser> Users { get; set; }
        public ChatType Type { get; set; }
    }
}
