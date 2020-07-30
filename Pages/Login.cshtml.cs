using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoffeeManagement.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public String Username { get; set; } = String.Empty;

        [BindProperty]
        public String Password { get; set; } = String.Empty;

        [BindProperty]
        public String FormMessage { get; set; } = String.Empty;

        public void OnPostSignIn() 
        {
            var cacheHelper = new Utilities.CacheHelper();
            if (String.IsNullOrEmpty(cacheHelper.GetKeyValue(Username)))
            {
                GoToDashBoardPage();
            }
            else
            {
                if (Utilities.User.Login(Username, Password)) 
                {
                    GoToDashBoardPage();
                }
            }
        }

        private IActionResult GoToDashBoardPage()
        {
            return Redirect("DashBoard");
        }

        public void OnPostSignUp() 
        {
            if (Utilities.User.SignUp(Username, Password))
            {
                GoToDashBoardPage();
            }
        }
    }
}
