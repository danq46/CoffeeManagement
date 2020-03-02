using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeManagement.DbUtilities
{
    public class Products : Database
    {
        public Products() 
        {
        }

        public DataTable GetAllProducts() 
        {
            return Procedure("proc_GetAllProducts").Execute<DataTable>();
        }
    }
}
