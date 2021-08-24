using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceSystem.Profile.BusinessObjects;
using ECommerceSystem.Profile.UniteOfWorks;

namespace ECommerceSystem.Profile.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductUniteOfWork _productUniteOfWork;

        public ProductService(IProductUniteOfWork productUniteOfWork)
        {
            _productUniteOfWork = productUniteOfWork;
        }

        public void CreateProduct(Product product)
        {
            _productUniteOfWork.Products.Add(new Entities.Product()
            {
                Name = product.Name,
                Price = product.Price
            });
            _productUniteOfWork.Save();
        }

        public void DeleteProduct(int id)
        {
            _productUniteOfWork.Products.Remove(id);
            _productUniteOfWork.Save();
        }

        public Product GetProduct(int id)
        {
            var product = _productUniteOfWork.Products.GetById(id);
            if (product == null) return null;

            return new Product()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };

        }

        public (IList<Product> records, int total, int totalDisplay) GetProducts(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var productData = _productUniteOfWork.Products.GetDynamic(
                string.IsNullOrWhiteSpace(searchText) ? null : x => x.Name.Contains(searchText),
                sortText, string.Empty, pageIndex, pageSize);

            var resultData = (from product in productData.data
                select (new Product()
                {
                    Id=product.Id,
                    Name = product.Name,
                    Price = product.Price
                })).ToList();

            return (resultData, productData.total, productData.totalDisplay);
        }

        public void UpdateProduct(Product product)
        {
            if (product == null)
                throw new InvalidOperationException("Product is Missing");

            var productEntity = _productUniteOfWork.Products.GetById(product.Id);
            if (productEntity!=null)
            {
                productEntity.Name = product.Name;
                productEntity.Price = product.Price;
                productEntity.Id = product.Id;
                _productUniteOfWork.Save();
            }
            else
            {
                throw new InvalidOperationException("Could not find Product");
            }
        }
    }
}
