using AutoMapper;
using ERP.BusinessEntity;
using ERP.BusinessService.Interface;
using ERP.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.BusinessService.Concreate
{
        public class RollService : IRollService
        {

            private IRoleRepository _roleRepository;

            private readonly IMapper _mapper;
         

            public RollService(IRoleRepository roleRepository, IMapper mapper)
            {
                _roleRepository = roleRepository;
                _mapper = mapper;
            }

            public List<RollViewModel> GetRolls()
            {
                var d = _roleRepository.GetRoles();
                return _mapper.Map<List<RollViewModel>>(d);
            }
    }
}
