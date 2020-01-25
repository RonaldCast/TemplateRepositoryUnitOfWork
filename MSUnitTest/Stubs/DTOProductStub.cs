using System;
using System.Collections.Generic;
using System.Text;
using TemplateUnitWorkRepository.DTO;

namespace MSUnitTest.Stubs
{
    public static class DTOProductStub
    {
        public static DTOProduct NewProduct = new DTOProduct()
        {
            Name = "Laptop"
        };

        public static IEnumerable<DTOProduct> ListProduct = new List<DTOProduct>()
        {
            new DTOProduct() {Name = "Laptop"},
            new DTOProduct() {Name = "Mesa"}
        };
    }
}
