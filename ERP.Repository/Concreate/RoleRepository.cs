using ERP.DataEntity;
using ERP.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Repository.Concreate
{
    public class RoleRepository : IRoleRepository
    {

        private readonly WeltecJobsContext _weltecJobsContext;

        public RoleRepository(WeltecJobsContext weltecJobsContext)
        {
            _weltecJobsContext = weltecJobsContext;
        }

       

        public bool AddEditRoll(UserRoleTbl role)
        {
            if (role.RoleId > 0)
            {
                var p = _weltecJobsContext.UserRoleTbls.Find(role.RoleId);
                p.RoleName = role.RoleName;
            }

            else
            {
                _weltecJobsContext.UserRoleTbls.Add(role);
            }

            return _weltecJobsContext.SaveChanges() > 0 ? true : false;
        }

        public bool DeleteRoll(int id)
        {
            var p = _weltecJobsContext.UserRoleTbls.Find(id);
            _weltecJobsContext.Remove(p);

            return _weltecJobsContext.SaveChanges() > 0 ? true : false;
        }

        public List<UserRoleTbl> GetRoles()
        {
            return _weltecJobsContext.UserRoleTbls.ToList();
        }

        public UserRoleTbl GetRoles(int id)
        {
            var p = _weltecJobsContext.UserRoleTbls.Find(id);
            return p;
        }
    }
}
