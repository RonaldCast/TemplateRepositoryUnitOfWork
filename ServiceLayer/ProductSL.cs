using DomainModel.Models;
using Persistence.UnitOfWork;
using ServiceLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer
{
   public class ProductSL : IProductSL
    {
        private readonly IUnitOfWork uow;
        public ProductSL(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void AddProduct(Product product)
        {
            
            uow.Product.AddProduct(product);
            uow.Save();
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

        public IEnumerable<Product> GetProducts()
        {

            return uow.Product.GetProducts();
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
                uow.Product.AddProduct(_product);
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
