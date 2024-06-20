using ERP.DataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Repository.Interface
{
    public interface IUserRepository
    {
        bool AddEditUser(UserRegistrectionTbl userRegistrectionTbl);

        bool DeleteUser(int id);

        UserRegistrectionTbl GetUsers(int id);
        List<UserRegistrectionTbl> GetUsers();


        UserRegistrectionTbl CheckLogin(string Email, String Password, out bool isSuc);

	}
}
