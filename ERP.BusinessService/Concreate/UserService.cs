using AutoMapper;
using ERP.BusinessEntity;
using ERP.BusinessService.Interface;
using ERP.Comman;
using ERP.DataEntity;
using ERP.Repository.Concreate;
using ERP.Repository.Interface;
using Microsoft.IdentityModel.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.BusinessService.Concreate
{
    public class UserService: IUserService
    {
        private IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public List<UserViewDisplayModel> GetUsers()
        {
            var d = _userRepository.GetUsers();
            return _mapper.Map<List<UserViewDisplayModel>>(d);
        }

		public bool AddEditUser(RegistrestionForm registrestionForm)
		{
			var p = _mapper.Map<UserRegistrectionTbl>(registrestionForm);
            var salt = Helper.GeneratePassword(7);

            p.PasswordSalt = salt;
            p.PasswordHash = Helper.EncodePassword(registrestionForm.Password, salt);
			p.RoleId = 1;

			return _userRepository.AddEditUser(p);

		}

        public UserViewDisplayModel CheckLogin(string Username, string password, out bool isSuc)
        {
            var p = _userRepository.CheckLogin(Username, password, out isSuc);
            return _mapper.Map<UserViewDisplayModel>(p);
        }

        public bool DeleteUser(int id)
        {
           return _userRepository.DeleteUser(id);   
        }

        public UserViewDisplayModel GetUsers(int id)
        {
            var d = _userRepository.GetUsers(id);

            return _mapper.Map<UserViewDisplayModel>(d);

        }
    }
}
