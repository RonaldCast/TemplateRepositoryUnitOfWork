using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSUnitTest.Stubs
{
    public class ProductStub
    {
        public static Product NewProduct = new Product()
        {
            Name = "Laptop"
        };

        public static IEnumerable<Product> ListProduct = new List<Product>()
        {
            new Product() {Name = "Laptop"},
            new Product() {Name = "Mesa"}
        };
    }
}
