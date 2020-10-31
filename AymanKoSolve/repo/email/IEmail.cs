using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AymanKoSolve.repo.email
{
   public interface IEmail
    {

        void Send(string from, string to, string subject, string html);

    }
}
