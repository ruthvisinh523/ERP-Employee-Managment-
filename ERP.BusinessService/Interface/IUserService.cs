using ERP.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.BusinessService.Interface
{
    public interface IUserService
    {
        List<UserViewDisplayModel> GetUsers();

        UserViewDisplayModel GetUsers(int id);

		bool AddEditUser(RegistrestionForm registrestionForm);
        bool DeleteUser(int id);
        UserViewDisplayModel CheckLogin(string username, string password, out bool isSuc);
    }
}
