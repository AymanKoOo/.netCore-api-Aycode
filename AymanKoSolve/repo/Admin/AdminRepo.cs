using AymanKoSolve.Models;
using AymanKoSolve.ModelViews.users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AymanKoSolve.repo.Admin
{
    public class AdminRepo : IAdminRepo
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _manager;

        public AdminRepo(ApplicationDbContext db,UserManager<ApplicationUser> manager)
        {
            _db = db;
            _manager = manager;
        }

        public async Task<ApplicationUser> AddNewUser(AddUserModel model)
        {
            if (model == null)
            {
                return null;
            }
            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                EmailConfirmed = model.EmailConfirmed,
                Country = model.Country,
                PhoneNumber = model.PhoneNumber
            };
            var result = await _manager.CreateAsync(user,model.Password);
            if (result.Succeeded)
            {
                return user;
            }
            return null;
        }

        public async Task<ApplicationUser> EditUser(string id)
        {
            if (id == null)
            {
                return null;
            }
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
          
            return user;
        }

        public async Task<ApplicationUser> EditUserTwo(editUserModel model)
        {
            if (model.Id == null) return null;

            var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == model.Id);

            _db.Users.Attach(user);


            user.UserName = model.UserName;
            user.Email = model.Email;
            user.EmailConfirmed = model.EmailConfirmed;
            user.Country = model.Country;
            user.PhoneNumber = model.PhoneNumber;

            if (model.Password != user.PasswordHash)
            {
             var result =   await _manager.RemovePasswordAsync(user);
                if (result.Succeeded)
                {
                    await _manager.AddPasswordAsync(user, model.Password);
                }
            }

            _db.Entry(user).Property(x => x.Email).IsModified = true;

            _db.Entry(user).Property(x => x.EmailConfirmed).IsModified = true;

            _db.Entry(user).Property(x => x.UserName).IsModified = true;

            _db.Entry(user).Property(x => x.PhoneNumber).IsModified = true;

            _db.Entry(user).Property(x => x.Country).IsModified = true;

            await _db.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<ApplicationUser>> GetUsers()
        {
            return await _db.Users.ToListAsync();
        }


    }
}
