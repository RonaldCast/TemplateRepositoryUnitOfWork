using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Contracts
{
    public interface IProductSL
    {
        void AddProduct(Product product);
        Product UpsertProduct(Product product);
        IEnumerable<Product> GetProducts();
        bool DeleteProduct(long productId);
        IEnumerable<Product> GetUserProducts(long userId);
        bool AddProductToUser(long userId, long productId);
    }
}
