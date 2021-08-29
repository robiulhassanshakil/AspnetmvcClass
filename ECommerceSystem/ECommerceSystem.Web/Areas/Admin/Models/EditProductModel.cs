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
    public class EditProductModel
    {
        private readonly IProductService _productService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public EditProductModel()
        {
            _productService = Startup.AutofacContainer.Resolve<IProductService>();
            _httpContextAccessor= Startup.AutofacContainer.Resolve<IHttpContextAccessor>();
        }
        public EditProductModel(IProductService productService, IHttpContextAccessor httpContextAccessor)
        {
            _productService = productService;
            _httpContextAccessor = httpContextAccessor;
        }

        internal void LoadModelData(int id)
        {
            var product = _productService.GetProduct(id);

            Id = product.Id;
            Name = product.Name;
            Price = product.Price;
        }

        internal void Update()
        {
            var product = new Product()
            {
                Id = Id,
                Name = Name,
                Price = Price
            };
            _productService.UpdateProduct(product);
        }
    }
}
