using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<MyUser> _userManager;
        private readonly SignInManager<MyUser> _signInManager;

        public AuthController(UserManager<MyUser> userManager, SignInManager<MyUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            MyUser user = new()
            {

                Name = registerVM.Name,
                Email = registerVM.Email,
                PhotoUrl = registerVM.Name,
                NormalizedEmail = registerVM.Email.ToUpper(),
                NormalizedUserName = registerVM.Name.ToUpper()



            };

            IdentityResult result = await _userManager.CreateAsync(user, registerVM.Password);


            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            var user = await _userManager.FindByEmailAsync(loginVM.Email);
            if (user == null) return View();
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("", "Auth", "Success");

            }

            return RedirectToAction(nameof(Login));


        }

    }
}
