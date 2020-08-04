using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CoffeeManagement.Utilities
{
    public class User : IdentityUser<Int32>
    {
        #region IdentityManagment
        private UserManager<User> _userManager { get; }
        private SignInManager<User> _signInManager { get; }

        #endregion

        public User()
        {
            // no
        }
        public void SignIn() 
        {
        }
    }
}
