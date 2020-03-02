using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Data;

namespace CoffeeManagement.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> productList = new List<Product>();

        internal class Product
        {
            private String ProductName;
            private String ProductDescription;
            private String ProductIngredients;
            private String ImageName;

            public Product(String productName, String productDescription, String productIngredients, String imageName) 
            {
                ProductName = productName;
                ProductDescription = productDescription;
                ProductIngredients = productIngredients;
                ImageName = imageName;
            }
        }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var products = Utilities.Products.GetProductsDataTable();
            foreach (DataRow row in products.Rows) 
            {
                var product = new Product(row["ProductName"].ToString(), row["ProductDescription "].ToString(), row["ProductIngredients "].ToString(), row["ImageName"].ToString());
                productList.Add(product);
            }
        }
    }
}
