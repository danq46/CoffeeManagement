using System;
using System.Collections.Generic;

using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CoffeeManagement.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoffeeManagement.Pages
{
    public class LoginModel : PageModel
    {
        private UserManager<User> _userManager { get; }
        private SignInManager<User> _signInManager { get; }
        
        [BindProperty]
        public FormMessage FormMessage { get; set; } = new FormMessage();

        [BindProperty]
        public String Username { get; set; } = String.Empty;

        [BindProperty]
        public String Email { get; set; } = String.Empty;

        [BindProperty]
        public String Password { get; set; } = String.Empty;

        public LoginModel(SignInManager<User> signInManager , UserManager<User> userManager) 
        {
            _userManager = userManager;
            _signInManager= signInManager;
        }

        public void OnPostSignIn() 
        {
           
        }

        private IActionResult GoToDashBoardPage()
        {
            return Redirect("DashBoard");
        }

        public async Task OnPostSignUp()
        {
            if (ModelState.IsValid)
            { 
                var user = new User { UserName = Username , Email = Email };
                var result = await _userManager.CreateAsync(user, Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    GoToDashBoardPage();
                }
                else 
                {
                    foreach (var error in result.Errors) 
                    {
                        FormMessage.Errors.Add(error.Description);
                    }
                }
            }
        }
    }
}
