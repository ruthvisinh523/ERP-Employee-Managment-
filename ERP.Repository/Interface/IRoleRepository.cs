using ERP.DataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Repository.Interface
{
    public interface IRoleRepository
    {
        bool AddEditRoll(UserRoleTbl role);

        bool DeleteRoll(int id);

        List<UserRoleTbl> GetRoles();

        UserRoleTbl GetRoles(int id);

    }
}
