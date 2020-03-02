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
        [BindProperty]
        public List<Product> products { get { return productList; } }

        private List<Product> productList = new List<Product>();
        public class Product
        {
            public String ProductName, 
                ProductDescription,
                ProductIngredients, 
                ImageName;

            public Boolean IsImageValid;

            public Product(String productName, String productDescription, String productIngredients, String imageName) 
            {
                ProductName = productName;
                ProductDescription = productDescription;
                ProductIngredients = productIngredients;
                ImageName = imageName;

                IsImageValid = IsValidImage(imageName);
            }

            private Boolean IsValidImage(string imageName)
            {
                var relativePath = String.Format("\\wwwroot\\img\\{0}.png", imageName);
                var trailEnd = "\\bin\\Debug\\netcoreapp3.1\\";
                var absolutePath = AppDomain.CurrentDomain.BaseDirectory.Replace(trailEnd, "");
                return System.IO.File.Exists(String.Format("{0}{1}" ,absolutePath, relativePath));
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
                var product = new Product(row["ProductName"].ToString(), row["ProductDescription"].ToString(), row["ProductIngredients"].ToString(), row["ImageName"].ToString());
                productList.Add(product);
            }
        }
    }
}
