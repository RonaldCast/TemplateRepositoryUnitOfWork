using DomainModel;
using DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void AddProduct(Product product)
        {
            _dbContext.Product.Add(product);
        }

        public void AddProductToUser(long userId, long productId)
        {
            _dbContext.UserProduct.Add(new UserProduct()
            {
                ProductId = productId,
                UserId = userId
            });
        }

        public bool DeleteProduct(long productId)
        {
            var removed = false;
            Product product = GetProduct(productId);
            if (product != null)
            {
                removed = true;
                _dbContext.Product.Remove(product);
            }

            return removed;
        }

        public Product GetProduct(long id)
        {
            return _dbContext.Product.Where(p => p.Id == id).FirstOrDefault();
        }

        public IEnumerable<Product> GetProducts()
        {
            return _dbContext.Product;
        }

        public IEnumerable<Product> GetUserProducts(long userId)
        {
            return _dbContext.UserProduct
                  .Include(up => up.Product)
                  .Where(up => up.UserId == userId)
                  .Select(p => p.Product)
                  .AsEnumerable();
        }
    }
}

