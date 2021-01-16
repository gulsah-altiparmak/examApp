using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Domain.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExamApp.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager,
                                      SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                //İlgili kullanıcıya dair önceden oluşturulmuş bir Cookie varsa siliyoruz.
                await _signInManager.SignOutAsync();
                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);
 
                if (result.Succeeded)
                    return RedirectToAction("ExamList","Exam");
            }
            else
            {
                ModelState.AddModelError("NotUser", "Böyle bir kullanıcı bulunmamaktadır.");
                ModelState.AddModelError("NotUser2", "E-posta veya şifre yanlış.");
            }
        }
        return View(model);
    }
      /*  [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
             var user1 = await _userManager.FindByEmailAsync(user.Email);
             var result = await _signInManager.CheckPasswordSignInAsync(user1, user.Password, false);
            if (result.Succeeded)
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user1.UserName)
            };
 
                var userIdentity = new ClaimsIdentity(claims, "login");
 
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
 
                //Just redirect to our index after logging in. 
                return RedirectToAction("Index","Home");
            }
            return View();
        }
       */
       
        //Pa$$w0rd
       /* [AllowAnonymous] 
       public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var user1 = await _userManager.FindByEmailAsync(user.Email);
                var result = await _signInManager.CheckPasswordSignInAsync(user1, user.Password, false);
                //var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, false,false);

                if (result.Succeeded)
                {
                    return RedirectToAction("ExamList", "Exam");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(user);
        }*/
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }


    }
}