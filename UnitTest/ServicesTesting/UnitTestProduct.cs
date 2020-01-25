using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTest.ServicesStub;
using Xunit;

namespace UnitTest.ServicesTesting
{
    public class UnitTestProduct
    {
        private SqliteFake _sqliteFake; 
        public UnitTestProduct()
        {
            _sqliteFake = new SqliteFake();
        }

        [Fact]
        public void CreateProduct()
        {
            //ARRANCE
            var product = ProductStub.NewProduct;

            //ACT
            //using (var context = _sqliteFake.GetContext())
            //{

            //    var serviceProduct = new ProductSL(;
            //}

            //ASSERT
        }
    }
}
