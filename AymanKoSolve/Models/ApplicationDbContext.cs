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

        public DbSet<problemHeader> problemHeader { get; set; }

        public DbSet<problemContent> problemContents { get; set; }

        public DbSet<problemSource> problemSources { get; set; }

        public DbSet<problemType> problemTypes { get; set; }
        /// <summary>
        /// /Chat
        /// </summary>
        public DbSet<Chatt> Chat { get; set; }
        public DbSet<Message> Message { get; set; }

        public DbSet<ChatUser> ChatUser { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ChatUser>()
                .HasKey(x => new { x.ChatId, x.UserId });
        }

    }
}
