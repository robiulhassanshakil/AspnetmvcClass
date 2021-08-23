using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ECommerceSystem.Data;
using ECommerceSystem.Profile.Contexts;
using ECommerceSystem.Profile.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace ECommerceSystem.Profile.Repositories
{
    public class ProductRepository : Repository<Product, int>, IProductRepository
    {
        public ProductRepository(IProductDbContext context)
            : base((DbContext)context)
        {

        }
    }
}
