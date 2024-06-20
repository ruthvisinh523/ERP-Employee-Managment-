using ERP.BusinessService.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ERP.BusinessEntity;

namespace ERP.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult LoginUser()
        {
            return View();
        }

     
        [HttpPost]
        public IActionResult LoginUser(LoginUserView loginUserView)
        {
            var d = _userService.CheckLogin(loginUserView.Email, loginUserView.Password, out bool suc);

           //d.RoleName = "Admin";
            if (!suc)
            {
                ViewBag.ErrorMessage = "Invalid UserName and Password";
            }
            else
            {
                var claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, Convert.ToString(d.UserId)),
                       new Claim(ClaimTypes.Name,d.Email),
                        //new Claim(ClaimTypes.Role,d.RoleName)

                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                //Initialize a new instance of the ClaimsPrincipal with ClaimsIdentity    
                var principal = new ClaimsPrincipal(identity);
                //SignInAsync is a Extension method for Sign in a principal for the specified scheme.    
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                {
                    IsPersistent = false,

                });

                return RedirectToAction("Index", "User");

            }
            return View("AddEditUser");
        }
    }
}
