using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AymanKoSolve.Models
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser,ApplicationRole,string>//Can add IdentityUser . but creating class make u add new filds
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

    }
}
