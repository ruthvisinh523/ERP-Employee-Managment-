
using ERP.Comman;
using ERP.DataEntity;
using ERP.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Repository.Concreate
{
    public class UserRepository : IUserRepository
    {
        private readonly WeltecJobsContext _weltecJobsContext;

        public UserRepository(WeltecJobsContext weltecJobsContext)
        {
            _weltecJobsContext = weltecJobsContext;
        }

        public bool AddEditUser(UserRegistrectionTbl userRegistrectionTbl)
        {
            if (userRegistrectionTbl.UserId > 0)
            {
                var p = _weltecJobsContext.UserRegistrectionTbls.Find(userRegistrectionTbl.UserId);
                p.Fname = userRegistrectionTbl.Fname;
                p.UserName = userRegistrectionTbl.UserName;
                p.Email = userRegistrectionTbl.Email;
                p.Dob = userRegistrectionTbl.Dob;
                p.Gender = userRegistrectionTbl.Gender;
                p.IssSub = userRegistrectionTbl.IssSub;
            }
            else
            {
                _weltecJobsContext.UserRegistrectionTbls.Add(userRegistrectionTbl);
            }

            return _weltecJobsContext.SaveChanges() > 0 ? true : false;
        }

        public UserRegistrectionTbl CheckLogin(string Email, string Password,out bool isSuc)
        {
            var user = _weltecJobsContext.UserRegistrectionTbls.FirstOrDefault(x=>x.Email == Email);
            if (user != null)
            {
                var passwordhash = Helper.EncodePassword(Password, user.PasswordSalt);

                if (passwordhash == user.PasswordHash)
                {
                    isSuc = true;
                    return user;
                }
                else
                {
                    isSuc = false;
                }
            }
            else
            {
                isSuc = false;
            }

            return null;

        }

        public bool DeleteUser(int id)
        {

            var p = _weltecJobsContext.UserRegistrectionTbls.Find(id);
            _weltecJobsContext.Remove(p);

            return _weltecJobsContext.SaveChanges()>0? true:false;

            
        }

        public UserRegistrectionTbl GetUsers(int id)
        {
            var p = _weltecJobsContext.UserRegistrectionTbls.Find(id);

            return p;
        }

        public List<UserRegistrectionTbl> GetUsers()
        {
             return _weltecJobsContext.UserRegistrectionTbls.Include(y=>y.Role).ToList();    
            //return null;
        }
    }
}
