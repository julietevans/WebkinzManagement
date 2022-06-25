using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using WebkinzManagement.Models;
using WebkinzManagement.ViewModels;
using System.Threading.Tasks;

namespace WebkinzManagement.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<User> signInManager;
        private UserManager<User> userManager;
        private RoleManager<IdentityRole> roleManager;
        public AccountController(SignInManager<User> _signin, UserManager<User> _user, RoleManager<IdentityRole> _role)
        {
            signInManager = _signin;
            userManager = _user;
            roleManager = _role;

        }

        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, loginViewModel.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError(string.Empty, "Failed to login");
            return View();
        }


        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                User newuser = new User()
                {
                    FirstName = registerViewModel.FirstName,
                    LastName = registerViewModel.LastName,
                    UserName = registerViewModel.UserName,
                    Email = registerViewModel.Email
                };
                var result = await userManager.CreateAsync(newuser, registerViewModel.Password);
                if (result.Succeeded)
                {
                    var addedUser = await userManager.FindByNameAsync(newuser.UserName);
                    if (addedUser.UserName == "Admin")
                    {
                        await userManager.AddToRoleAsync(addedUser, "Admin");
                        await userManager.AddToRoleAsync(addedUser, "User");
                    }
                    else
                    {
                        await userManager.AddToRoleAsync(addedUser, "User");
                    }
                    return RedirectToAction("Login", "Account");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View();
        }


        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
