using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceSystem.Data;
using ECommerceSystem.Profile.Contexts;
using ECommerceSystem.Profile.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSystem.Profile.UniteOfWorks
{
    public class ProductUniteOfWork : UnitOfWork, IProductUniteOfWork
    {
        public IProductRepository Products { get; set; }

        public ProductUniteOfWork(IProductDbContext context,
            IProductRepository product) : base((DbContext)context)
        {
            Products = product;
        }
    }
}
