using AutoMapper;
using ERP.BusinessEntity;
using ERP.DataEntity;

namespace ERP.MappingUserRoleTbl
{
    public class AutoMapparRegistrestion : Profile
    {
        public AutoMapparRegistrestion() {

            CreateMap<UserViewDisplayModel, UserRegistrectionTbl>().ReverseMap().
           
          ForMember(y => y.RoleName,op => op.MapFrom(p => p.Role.RoleName)); 
             /*    
                ForMember(y => y.RoleName, op => op.MapFrom(p => p.))
                 .ForMember(y => y.Age, op => op.MapFrom(p => System.DateTime.Now.Year - p.Dob.Year));
           */

            CreateMap<RollViewModel, UserRoleTbl>().ReverseMap();

            CreateMap<RegistrestionForm,UserRegistrectionTbl>().ReverseMap();
        }

    }
}
