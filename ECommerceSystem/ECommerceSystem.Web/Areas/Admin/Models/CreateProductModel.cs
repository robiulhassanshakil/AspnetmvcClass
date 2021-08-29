using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using ECommerceSystem.Profile.BusinessObjects;
using ECommerceSystem.Profile.Services;
using Microsoft.AspNetCore.Http;

namespace ECommerceSystem.Web.Areas.Admin.Models
{
    public class CreateProductModel
    {
        private readonly IProductService _productService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public string Name { get; set; }
        public double Price { get; set; }

        public CreateProductModel()
        {
            _productService = Startup.AutofacContainer.Resolve<IProductService>();
            _httpContextAccessor= Startup.AutofacContainer.Resolve<IHttpContextAccessor>();
        }
        public CreateProductModel(IProductService productService, IHttpContextAccessor httpContextAccessor)
        {
            _productService = productService;
            _httpContextAccessor = httpContextAccessor;
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
