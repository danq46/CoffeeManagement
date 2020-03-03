using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeManagement.Utilities
{
    public static class Common
    {
        public static User adminUser = new User("admin","12345");
        public const String connectionString = "Initial Catalog = CoffeManagement; Data Source = DESKTOP-6SE50ED\\SQLSERVER; User ID = sa; Password = 12345";
    }
}
