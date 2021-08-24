using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using ECommerceSystem.Profile.BusinessObjects;
using ECommerceSystem.Profile.Services;

namespace ECommerceSystem.Web.Areas.Admin.Models
{
    public class CreateProductModel
    {
        private readonly IProductService _productService;
        public string Name { get; set; }
        public double Price { get; set; }

        public CreateProductModel()
        {
            _productService = Startup.AutofacContainer.Resolve<IProductService>();
        }
        public CreateProductModel(IProductService productService)
        {
            _productService = productService;
        }

        public void CreateProduct()
        {
            var product = new Product()
            {
                Name = Name,
                Price = Price
            };
            _productService.CreateProduct(product);

        }
    }
}
