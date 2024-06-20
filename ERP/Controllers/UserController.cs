using Azure.Messaging;
using ERP.BusinessEntity;
using ERP.BusinessService.Concreate;
using ERP.BusinessService.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{

   // [Authorize(Roles = "User")]
    public class UserController : Controller
    {
        private IUserService userService;
        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        public IActionResult GoData()
        {
            var d = userService.GetUsers();
            return Json(new { data = d });
        }

        public IActionResult Index() {

            return View();
        }

		public IActionResult AddEditUser()
		{
			
            return View("Index", "User");

		}
		[HttpPost]
		public IActionResult AddEditUser(RegistrestionForm registrestionForm)
		{
			userService.AddEditUser(registrestionForm);

			return View("Index", "User");
			
		}
        [HttpPost]
        public JsonResult DeleteUser(int id ) {
            
            var p = userService.DeleteUser(id);

            return Json(new { Result = p , Message = "Deleted record" });


          
        }

	}
}
