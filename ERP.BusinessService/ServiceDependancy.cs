using ERP.BusinessService.Concreate;
using ERP.BusinessService.Interface;
using ERP.Repository.Concreate;
using ERP.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.BusinessService
{
    public static class ServiceDependancy
    {
        public static void Registration(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<IRollService, RollService>();
        }
    }
}
