using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contracts
{
    public interface IProductRepository
    {
        Task AddProductAsync(Product product);
        Product GetProduct(long id);
        Task<IEnumerable<Product>> GetProductsAsync();
        bool DeleteProduct(long productId);
        IEnumerable<Product> GetUserProducts(long userId);
        void AddProductToUser(long userId, long productId);

    }
}
