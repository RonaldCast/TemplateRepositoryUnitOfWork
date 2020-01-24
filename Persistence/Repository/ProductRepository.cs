using DomainModel;
using DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task AddProductAsync(Product product)
        {
              await _dbContext.Product.AddAsync(product);
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

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return  await _dbContext.Product.ToListAsync();
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

