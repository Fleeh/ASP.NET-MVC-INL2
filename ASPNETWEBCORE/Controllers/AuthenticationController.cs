using ASPNETWEBCORE.Helpers;
using ASPNETWEBCORE.Models;
using ASPNETWEBCORE.Models.data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETWEBCORE.Controllers
{
    
    public class AuthenticationController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAddressManager _addressManager;

        public AuthenticationController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, IAddressManager addressManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _addressManager = addressManager;
        }

        #region SignUp
        public IActionResult SignUp(string returnUrl = null)
        {
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Home");

            var form = new SignUpModel();

            if (returnUrl != null)
                form.ReturnUrl = returnUrl;

            return View(form);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpModel form)
        {
            if (ModelState.IsValid)
            {
                if (!_roleManager.Roles.Any())
                {
                   await _roleManager.CreateAsync(new IdentityRole("admin"));
                    await _roleManager.CreateAsync(new IdentityRole("user"));
                }

                if (!_userManager.Users.Any())
                    form.RoleName = "admin";


                var user = new AppUser()
                {
                    FirstName = form.FirstName,
                    LastName = form.LastName,
                    Email = form.Email,
                    UserName = form.Email
                };

                var response = await _userManager.CreateAsync(user, form.Password);
                if (response.Succeeded)
                {
                    var address = new ApplicationAddress()
                    {
                        AddressLine = form.AddressLine,
                        PostalCode = form.PostalCode,
                        City = form.City
                    };
                    await _addressManager.CreateUserAddressAsync(user, address);
                    await _userManager.AddToRoleAsync(user, form.RoleName);
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    if (form.ReturnUrl == null || form.ReturnUrl == "/")
                        return RedirectToAction("Index", "Home");
                    else
                        return LocalRedirect(form.ReturnUrl);
                }

                foreach( var error in response.Errors)                
                    ModelState.AddModelError(string.Empty, error.Description);
                
            }

            return View();
        }



        #endregion


        #region SignIn
        public IActionResult SignIn(string returnUrl = null)
        {
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Home");

            var model = new SignInModel();

            if (returnUrl != null)
                model.ReturnUrl = returnUrl;
            else
                model.ReturnUrl = "/";

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, false);
                if (result.Succeeded)
                {
                    if (model.ReturnUrl == null || model.ReturnUrl == "/")
                        return RedirectToAction("Index", "Home");
                    else
                        return LocalRedirect(model.ReturnUrl);
                }
            }

            ModelState.AddModelError(string.Empty, "Incorrect email or password");
            return View();
        }
        #endregion

        #region SignOut
        [Authorize]
        public async Task<IActionResult> SignOut()
        {
            if (_signInManager.IsSignedIn(User))
                await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
        #endregion



    }
}
