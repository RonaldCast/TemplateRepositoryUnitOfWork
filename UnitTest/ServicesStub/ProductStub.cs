using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using TemplateUnitWorkRepository.DTO;

namespace UnitTest.ServicesStub
{
    public static class ProductStub
    {
        public static Product NewProduct = new Product()
        {
            Name = "Laptop"
        };

        public static List<Product> ListProduct = new List<Product>()
        {
            new Product() {Name = "Laptop"},
            new Product() {Name = "Mesa"}
        };
    }
}
