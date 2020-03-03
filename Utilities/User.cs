using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeManagement.Utilities
{
    public class User
    {
        public String UserName
        {
            get { return uUsername; }
            set { uUsername = value; }
        }
        public Boolean IsAuth 
        {
            get { return uIsAuth; }
            set { uIsAuth = value; }
        }

        private static String uUsername;
        private static Boolean uIsAuth;
        public User(String username, String password) 
        {
        
        }
        private static void SetUserCache()
        {
            var cacheHelper = new CacheHelper();
            cacheHelper.AddKey("username", uUsername);
        }
        public static Boolean Login(String username, String password) 
        {
            var isAuth = username.Equals(Common.adminUser.UserName);
            DbUtilities.User.LoginUser(username, password, out isAuth);
            if (isAuth)
            {
                uUsername = username;
                uIsAuth = true;
                SetUserCache();
            }
            return isAuth;
        }

        public static Boolean SignUp(String username, String password) 
        {
            var signedUp = false;
            DbUtilities.User.SignUpUser(username, password, out signedUp);
            return signedUp;
        }
    }
}
