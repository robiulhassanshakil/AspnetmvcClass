using System.Collections.Generic;
using ECommerceSystem.Profile.BusinessObjects;

namespace ECommerceSystem.Profile.Services
{
    public interface IProductService
    {
        void CreateProduct(Product product);
         (IList<Product> records,int total,int totalDisplay)GetProducts(int pageIndex, int pageSize, string searchText, string sortText);
        Product GetProduct(int id);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}