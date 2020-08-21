using AymanKoSolve.Models;
using AymanKoSolve.ModelViews.users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AymanKoSolve.repo.Admin
{
    public interface IAdminRepo
    {
        Task<IEnumerable<ApplicationUser>> GetUsers();

        Task<ApplicationUser> AddNewUser(AddUserModel model);


        Task<ApplicationUser> EditUser(string id);


        Task<ApplicationUser> EditUserTwo(editUserModel model);
    }
}
