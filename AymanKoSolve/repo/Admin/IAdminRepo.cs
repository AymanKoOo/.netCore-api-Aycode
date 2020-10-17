using AymanKoSolve.Models;
using AymanKoSolve.ModelViews.problem;
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

        Task<bool> DeleteUser(string id);

        /// ///////////ProblemSource////////////////////
        Task<problemSource> AddprobSource (addProblemSource model);

        Task<problemSource> EditprobSource(addProblemSource model);

        Task<bool> DeleteprobSource(int id);

        Task<problemSource> GetprobSource(int sourceId);

        Task<object> GetAllprobSource();

        /////////////////////////////////////
        ///
        /// ///////////ProblemType////////////////////
        Task<problemType> AddprobType(problemType model);

        Task<problemType> EditprobType(problemType model);

        Task<bool> DeleteprobType(int id);

        Task<problemType> GetprobType(int probId);

        Task<IEnumerable<problemType>> GetAllprobType();

        /////////////Problem Header////////////////////////
        Task<problemHeader> AddprobHeader(addProblemHeader model);

        Task<problemHeader> EditprobHeader(problemHeader model);

        Task<bool> DeleteprobHeader(int id);

        Task<object> GetprobHeader(int probId);

        Task<object> GetAllprobHeader();

        /////////////////////////////////////
        ///
           /////////////Problem content////////////////////////
        Task<problemContent> Addprobcontent(problemContent model);

        Task<problemContent> Editprobcontent(problemContent model);

        Task<bool> Deleteprobcontent(int id);

        Task<object> Getprobcontent(int probId);

        Task<object> GetprobcontentbyName(string probName);
        Task<object> GetAllprobcontent();

        /////////////////////////////////////
        Task<object> GetprobHeaderJ(string probType,string probSource);
        Task<object> GetprobContentJ(string probHeaderName);

        string GetUserRole(string id);

        Task<object> GetAllUserData(string userID);

    }
}
