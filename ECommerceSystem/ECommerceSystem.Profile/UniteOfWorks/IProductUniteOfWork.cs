using ECommerceSystem.Data;
using ECommerceSystem.Profile.Repositories;

namespace ECommerceSystem.Profile.UniteOfWorks
{
    public interface IProductUniteOfWork : IUnitOfWork
    {
        IProductRepository Products { get;}
    }
}