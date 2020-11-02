using AymanKoSolve.Models;
using AymanKoSolve.ModelViews.problem;
using AymanKoSolve.ModelViews.users;
using Microsoft.AspNetCore.Identity;
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

        public async Task<problemSource> AddprobSource(addProblemSource model)
        {
            if (model == null) return null;

            var probSource = new problemSource
            {

                sourceName = model.sourceName,

                problemSourceImage = model.problemSourceImage,

                sourceDescription = model.sourceDescription

            };
            var result = await _db.AddAsync(probSource);
            await _db.SaveChangesAsync();
            return probSource;
        }
        public async Task<object> GetAllprobSource()
        {
          //  var sources = _db.problemSources.ToListAsync();
            var sources = await (from a in _db.problemSources
                
                             select new
                             {
                                 sourceName = a.sourceName,
                                 problemSourceImage = a.problemSourceImage,
                                 sourceDescription = a.sourceDescription,
                             }).ToListAsync();
            return sources;
        }


        public async Task<bool> DeleteUser(string id)
        {
            if (id == null) return false;

            var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == id);

            var result = await _manager.DeleteAsync(user);

            if (result.Succeeded)
            {
                return true;
            }
            return true;
        }

        public async Task<problemSource> EditprobSource(addProblemSource model)
        {
            if (model == null) return null;

            var probSource = await _db.problemSources.FirstOrDefaultAsync(x => x.problemSourceID == model.problemSourceID);
            

            _db.problemSources.Attach(probSource);

            probSource.sourceName = model.sourceName;
            probSource.sourceDescription = model.sourceDescription;
            probSource.problemSourceImage = model.problemSourceImage;
   

            _db.Entry(probSource).Property(x => x.sourceName).IsModified = true;

            _db.Entry(probSource).Property(x => x.sourceDescription).IsModified = true;

            _db.Entry(probSource).Property(x => x.problemSourceImage).IsModified = true;

            await _db.SaveChangesAsync();
            return probSource;
        }


        public async Task<bool> DeleteprobSource(int id)
        {
            if (id == null) return false;
            var probSource = await _db.problemSources.FirstOrDefaultAsync(x => x.problemSourceID == id);

            if (probSource != null) {
                var result = _db.problemSources.Remove(probSource);
                await _db.SaveChangesAsync();
                return true;
            };

            return false;
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


        public Task<problemSource> GetprobSource(int sourceId)
        {
            if (sourceId < 0) return null;

            var source = _db.problemSources.FirstOrDefaultAsync(x => x.problemSourceID == sourceId);
            if (source != null) return source;
            return null;
        }

        public async Task<IEnumerable<ApplicationUser>> GetUsers()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<problemType> AddprobType(problemType model)
        {
            if (model == null) return null;

            var problemType = new problemType
            {

                problemTypee = model.problemTypee,

                problemTypeImage = model.problemTypeImage,

                problemTDescription = model.problemTDescription

            };
            var result = await _db.AddAsync(problemType);
            await _db.SaveChangesAsync();
            return problemType;
        }

        public async Task<problemType> EditprobType(problemType model)
        {
            if (model == null) return null;

            var problemType = await _db.problemTypes.FirstOrDefaultAsync(x => x.problemTypeID == model.problemTypeID);


            _db.problemTypes.Attach(problemType);

            problemType.problemTypee = model.problemTypee;
            problemType.problemTDescription = model.problemTDescription;
            problemType.problemTypeImage = model.problemTypeImage;


            _db.Entry(problemType).Property(x => x.problemTypee).IsModified = true;

            _db.Entry(problemType).Property(x => x.problemTDescription).IsModified = true;

            _db.Entry(problemType).Property(x => x.problemTypeImage).IsModified = true;

            await _db.SaveChangesAsync();
            return problemType;
        }

        public async Task<bool> DeleteprobType(int id)
        {
            if (id < 0) return false;
            var problemType = await _db.problemTypes.FirstOrDefaultAsync(x => x.problemTypeID == id);

            if (problemType != null)
            {
                var result = _db.problemTypes.Remove(problemType);
                await _db.SaveChangesAsync();
                return true;
            };
            return false;
        }

        public async Task<problemType> GetprobType(int probId)
        {
            if (probId < 0) return null;

            var probType = await _db.problemTypes.FirstOrDefaultAsync(x => x.problemTypeID == probId);
            if (probType != null) return probType;
            return null;
        }

        public async Task<IEnumerable<problemType>> GetAllprobType()
        {
            var probType = _db.problemTypes.ToListAsync();
            
            if (probType != null) return await probType;
            return null;
        }
        /// <summary>
        /// ////////////////////////////////////////
        ///            Problem Header           ///
        /// ///////////////////////////////////////
        
        public async Task<problemHeader> AddprobHeader(addProblemHeader model)
        {
            if (model == null) return null;


            var probTypeIDobj = _db.problemTypes.Where(x => x.problemTypee == model.problemType).Select(x => new { x.problemTypeID });
            int problemTypeIDD = probTypeIDobj.FirstOrDefault().problemTypeID;

            var probSoruceIDobj = _db.problemSources.Where(x=>x.sourceName==model.problemSource).Select(x => new { x.problemSourceID });
            int problemSourceIDD = probSoruceIDobj.FirstOrDefault().problemSourceID;

            var problemHeadr = new problemHeader
            {
                problemName = model.problemName,

                problemDescription = model.problemDescription,

                problemImage = model.problemImage,

                date = model.date,

                problemTypeID = problemTypeIDD,
                problemSourceID = problemSourceIDD
            };
            var result = await _db.AddAsync(problemHeadr);
            await _db.SaveChangesAsync();

            return problemHeadr;
        }

        public async Task<problemHeader> EditprobHeader(problemHeader model)
        {
            if (model == null) return null;

            var problemHeader = await _db.problemHeader.FirstOrDefaultAsync(x => x.problemid == model.problemid);


            _db.problemHeader.Attach(problemHeader);

            problemHeader.problemName = model.problemName;
            problemHeader.problemDescription = model.problemDescription;
            problemHeader.problemImage = model.problemImage;
            problemHeader.date = model.date;
            problemHeader.problemTypeID = model.problemTypeID;
            problemHeader.problemSourceID = model.problemSourceID;
       
            _db.Entry(problemHeader).Property(x => x.problemName).IsModified = true;

            _db.Entry(problemHeader).Property(x => x.problemDescription).IsModified = true;

            _db.Entry(problemHeader).Property(x => x.problemImage).IsModified = true;

            _db.Entry(problemHeader).Property(x => x.date).IsModified = true; 

            _db.Entry(problemHeader).Property(x => x.problemTypeID).IsModified = true; 

            _db.Entry(problemHeader).Property(x => x.problemSourceID).IsModified = true;


            await _db.SaveChangesAsync();
            return problemHeader;
        }

        public async Task<bool> DeleteprobHeader(int id)
        {
            if (id < 0) return false;
            var problemHeader = await _db.problemHeader.FirstOrDefaultAsync(x => x.problemid == id);

            if (problemHeader != null)
            {
                var result = _db.problemHeader.Remove(problemHeader);
                await _db.SaveChangesAsync();
                return true;
            };
            return false;
        }

        public async Task<object> GetprobHeader(int probId)
        {
          
            if (probId < 0) return null;
            var res = await (from h1 in _db.problemHeader

                      join t2 in _db.problemTypes
                          on h1.problemTypeID equals t2.problemTypeID

                      join s2 in _db.problemSources
                        on h1.problemSourceID equals s2.problemSourceID

                      where h1.problemid == probId

                       select new {
                           
                           problemHead = h1.problemName,
                           problemDescription = h1.problemDescription,
                           problemImage = h1.problemImage,
                           date = h1.date,

                           sourceName = s2.sourceName,
                           sourceDescription = s2.sourceDescription,
                           problemSourceImage = s2.problemSourceImage,

                           problemTypee = t2.problemTypee,
                           problemTypeImage = t2.problemTypeImage,
                           problemTDescription = t2.problemTDescription

                       }).ToListAsync();
          
            //var problemHeader = await _db.problemHeader.FirstOrDefaultAsync(x => x.problemid == probId);
            return res;
        }

        public async Task<object> GetAllprobHeader()
        {
         
            var res = await (from h1 in _db.problemHeader

                             join t2 in _db.problemTypes
                                 on h1.problemTypeID equals t2.problemTypeID

                             join s2 in _db.problemSources
                               on h1.problemSourceID equals s2.problemSourceID

                       
                             select new
                             {
                                 problemid = h1.problemid,
                                 problemHead = h1.problemName,

                                 problemDescription = h1.problemDescription,
                                 problemImage = h1.problemImage,
                                 date = h1.date,

                                 sourceName = s2.sourceName,
                                 sourceDescription = s2.sourceDescription,
                                 problemSourceImage = s2.problemSourceImage,

                                 problemTypee = t2.problemTypee,
                                 problemTypeImage = t2.problemTypeImage,
                                 problemTDescription = t2.problemTDescription

                             }).ToListAsync();
            return res;
        }

        /// <summary>
        /// ////////////////////////////////////////
        /// </summary>
     
        public async Task<problemContent> Addprobcontent(problemContent model)
        {
            if (model == null) return null;

            var problemContent = new problemContent
            {
                contentProblemName = model.contentProblemName,

                contentProblemDescription = model.contentProblemDescription,

                contentproblemImage = model.contentproblemImage,

                code = model.code,

                date = model.date,

                problemHeaderID = model.problemHeaderID
            };
            var result = await _db.AddAsync(problemContent);
            await _db.SaveChangesAsync();

            return problemContent;
        }

        public Task<problemContent> Editprobcontent(problemContent model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Deleteprobcontent(int id)
        {
            if (id < 0) return false;
            var problemContent = await _db.problemContents.FirstOrDefaultAsync(x => x.contentProblemid == id);

            if (problemContent != null)
            {
                var result = _db.problemContents.Remove(problemContent);
                await _db.SaveChangesAsync();
                return true;
            };
            return false;
        }

        public async Task<object> Getprobcontent(int probId)
        {
            if (probId < 0) return null;
            var res = await(from c1 in _db.problemContents

                            join h1 in _db.problemHeader
                                on c1.problemHeaderID equals h1.problemid

                            where c1.contentProblemid == probId

                            select new
                            {

                                contentProblemid = c1.contentProblemid,
                                contentProblemName = c1.contentProblemName,
                                contentProblemDescription = c1.contentProblemDescription,
                                contentproblemImage = c1.contentproblemImage,
                                code = c1.code,
                                date = c1.date,

                                problemHead = h1.problemName,
                          
                            }).ToListAsync();

             return res;
        }

        public async Task<object> GetAllprobcontent()
        {
            var res = await(from c1 in _db.problemContents

                            join h1 in _db.problemHeader
                                on c1.problemHeaderID equals h1.problemid


                            select new
                            {

                                contentProblemid = c1.contentProblemid,
                                contentProblemName = c1.contentProblemName,
                                contentProblemDescription = c1.contentProblemDescription,
                                contentproblemImage = c1.contentproblemImage,
                                code = c1.code,
                                date = c1.date,

                                problemHead = h1.problemName,

                            }).ToListAsync();

            return res;
        }

        public async Task<object> GetprobHeaderJ(string probType,string probSource)
        {
            //var res = await _db.problemHeader.FromSqlRaw("select * from [dbo].[problemHeader] as a inner join[dbo].[problemSources] as b on a.problemSourceID = b.problemSourceID inner join[dbo].[problemTypes] as c on a.problemTypeID = c.problemTypeID").ToListAsync();

            var res = await (from a in _db.problemHeader

                             join b in _db.problemSources

                                 on a.problemSourceID equals b.problemSourceID

                             join c in _db.problemTypes

                                 on a.problemTypeID equals c.problemTypeID

                             where (b.sourceName == probType && c.problemTypee == probSource)

                             select new
                             {
                                 ProblemName = a.problemName,
                                 problemDescription=a.problemDescription,
                                 problemImage=a.problemImage,
                                 date=a.date

                             }).ToListAsync();

            return res;
        }

        public async Task<object> GetprobContentJ(string probHeaderName)
        {
            try
            {
                var probHeaderID = await (
                            from b in _db.problemHeader
                            where (b.problemName == probHeaderName)
                            select b.problemid
                            ).ToListAsync();

                var res = await (from a in _db.problemContents
                                 where a.problemHeaderID == probHeaderID[0]
                                 select new
                                 {
                                     contentName = a.contentProblemName,
                                     contentDesc=a.contentProblemDescription,
                                     contentCode = a.code,
                                     contentImage=a.contentproblemImage
                                 }).ToListAsync();

                return res;
            }
            catch
            {
                return null;
            }


           
          
        }

        public async Task<object> GetprobcontentbyName(string probName)
        {
            if (probName ==null) return null;
            var res = await(from c1 in _db.problemContents

                            where c1.contentProblemName == probName

                            select new
                            {

                              
                                contentProblemName = c1.contentProblemName,
                                contentProblemDescription = c1.contentProblemDescription,
                                contentproblemImage = c1.contentproblemImage,
                                code = c1.code,
                                date = c1.date,

                            }).ToListAsync();

            return res;
        }

        public string GetUserRole(string id)
        {
            var roleIdOb =  _db.UserRoles.Where(x => x.UserId == id).Select(x => new { x.RoleId });
            
            string roleID = roleIdOb.FirstOrDefault().RoleId;
            if (roleID == null) return null;
            var roleNameOb =  _db.Roles.Where(x => x.Id == roleID).Select(x => new { x.Name });
            string roleName = roleNameOb.FirstOrDefault().Name;

            if (roleName == null)
            {
                return null;
            }
             return roleName;
        }

        public async Task<object> GetAllUserData(string userId)
        {
            var user = await (from u1 in _db.Users
                             where u1.Id == userId
                             select new
                             {
                                 Email = u1.Email,
                                 EmailConfirmed = u1.EmailConfirmed,
                                 Country = u1.Country,
                                 PicPath = u1.PicPath,
                                 UserName = u1.UserName,
                             }).ToListAsync();

            return user;
        }
    }
}
