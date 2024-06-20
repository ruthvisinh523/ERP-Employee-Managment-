using ERP.Repository.Concreate;
using ERP.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Repository
{
    public static class RepositoryDependancyContainer
    {
        public static void Registration(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddScoped<IRoleRepository, RoleRepository>();
        }
    }
}
