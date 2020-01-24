using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Contracts
{
    public interface IProductSL
    {
        Task<int> AddProductAsync(Product product);
        Product UpsertProduct(Product product);
        Task<IEnumerable<Product>> GetProductsAsync();
        bool DeleteProduct(long productId);
        IEnumerable<Product> GetUserProducts(long userId);
        bool AddProductToUser(long userId, long productId);
    }
}
