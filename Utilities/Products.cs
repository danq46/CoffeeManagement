using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeManagement.Utilities
{
    public static class Products
    {
        public static DataTable GetProductsDataTable() 
        {
            var products = new DbUtilities.Products();
            return products.GetAllProducts();
        }
    }
}
