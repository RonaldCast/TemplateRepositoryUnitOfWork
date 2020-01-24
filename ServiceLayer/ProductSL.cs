using DomainModel.Models;
using Microsoft.Extensions.Logging;
using Persistence.UnitOfWork;
using ServiceLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
   public class ProductSL : IProductSL
    {
        private readonly IUnitOfWork uow;
        private readonly ILogger<ProductSL> _logger;
        public ProductSL(IUnitOfWork uow, ILogger<ProductSL> logger)
        {
            this.uow = uow;
            _logger = logger;
        }

        public async Task<int> AddProductAsync(Product product)
        {
            
            await uow.Product.AddProductAsync(product);
           return await uow.SaveAsync();
        }

        public bool AddProductToUser(long userId, long productId)
        {
            if (userId <= default(int))
                throw new ArgumentException("Invalid user id");
            if (productId <= default(int))
                throw new ArgumentException("Invalid product id");

            if (uow.Product.GetProduct(productId) == null)
                throw new InvalidOperationException("Invalid product");

            if (uow.User.GetUser(userId) == null)
                throw new InvalidOperationException("Invalid user");

            var userProducts = uow.Product.GetUserProducts(userId);

            if (userProducts.Any(up => up.Id == productId))
                throw new InvalidOperationException("Products are already mapped");

            uow.Product.AddProductToUser(userId, productId);
            uow.Save();

            return true;
        }

        public bool DeleteProduct(long productId)
        {
            if (productId <= default(int))
                throw new ArgumentException("Invalid produt id");

            var isremoved = uow.Product.DeleteProduct(productId);
            if (isremoved)
                uow.Save();

            return isremoved;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            _logger.LogInformation("Into the productSL");
            return await uow.Product.GetProductsAsync();
        }

        public IEnumerable<Product> GetUserProducts(long userId)
        {
            
            if (userId <= default(int))
                throw new ArgumentException("Invalid user id");

            return uow.Product.GetUserProducts(userId);
        }

        public Product UpsertProduct(Product product)
        {
            if (product == null)
                throw new ArgumentException("Invalid product details");

            if (string.IsNullOrWhiteSpace(product.Name))
                throw new ArgumentException("Invalid product name");

            var _product = uow.Product.GetProduct(product.Id);
            if (_product == null)
            {
                _product = new Product
                {
                    Name = product.Name
                };
                uow.Product.AddProductAsync(_product);
            }
            else
            {
                _product.Name = product.Name;
            }

            uow.Save();

            return _product;
        }
    }

}
