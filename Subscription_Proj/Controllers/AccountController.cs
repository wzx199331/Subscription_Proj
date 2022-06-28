using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Subscription_Proj.Models;
using Subscription_Proj.ViewModels;
using System.Threading.Tasks;

namespace Subscription_Proj.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<User> signInManager;
        private UserManager<User> userManager;
        private RoleManager<IdentityRole> roleManager;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.signInManager=signInManager;
            this.userManager=userManager;
            this.roleManager=roleManager;
            
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
                return RedirectToAction("Index","Home");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if(ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, loginViewModel.RememberMe, false);
                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("","Failed to login");
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if(ModelState.IsValid)
            {
                User newUser = new User()
                {
                    FirstName = registerViewModel.FirstName,
                    LastName = registerViewModel.LastName,
                    UserName = registerViewModel.UserName,
                    PhoneNumber = registerViewModel.PhoneNumber,
                    Email = registerViewModel.Email,
                };

                var result = await userManager.CreateAsync(newUser, registerViewModel.Password);

                if(result.Succeeded)
                {
                    var addedUser = await userManager.FindByNameAsync(registerViewModel.UserName);
                    if (addedUser.UserName == "Admin")
                        await userManager.AddToRoleAsync(addedUser, "Admin");
                    await userManager.AddToRoleAsync(addedUser, "Customer");

                    return RedirectToAction("Login", "Account");
                }

                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
