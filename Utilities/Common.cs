using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeManagement.Utilities
{
    public class Common
    {
        private static String _connectionString;
        public Common(IOptions<SettingModel> options) 
        {
            _connectionString = options.Value.ConnectionString;
        }
        public static string ConnectionString
        {
            get { return _connectionString ?? "Initial Catalog = CoffeManagement; Data Source = DESKTOP-6SE50ED\\SQLSERVER; User ID = sa; Password = 12345"; }
        }
        //public static User AdminUser
        //{
        //}
        
    }
}
