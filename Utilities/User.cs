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
        private String _username;
        private Boolean isAuth;

        public String Username
        {
            get { return _username; }
            set { _username = value; }
        }
        public Boolean IsAuth
        {
            get { return isAuth; }
            set { isAuth = value; }
        }
        public User(String username, String password) 
        {
            var user = new DbUtilities.User(username, password);
            this.Username = user.Username;
            this.IsAuth = user.UserID > 0;
            if (IsAuth)
                SetUserCache();
        }
        private void SetUserCache()
        {
            var cacheHelper = new CacheHelper();
            cacheHelper.AddKey("username", Username);
        }
    }
}
