using AutoMapper;
using FluentAssertions;
using Castle.Core.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using Moq;
using MSUnitTest.Stubs;
using Persistence.UnitOfWork;
using ServiceLayer;
using ServiceLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TemplateUnitWorkRepository.Controllers;
using DomainModel.Models;
using TemplateUnitWorkRepository.DTO;

namespace MSUnitTest.ControllersTesting
{
    [TestClass]
    public class ProductControllerTest
    {
        Mock<IProductSL> _mockProductSL;
        Mock<IMapper> _mockMapper;
        Mock<ILogger<ProductController>> _mockLogger;
       // Mock<IUnitOfWork> _mockUnitOfWork;
        ProductController _mockProductController;

        [TestInitialize]
        public void Initialize()
        {
            _mockProductSL = new Mock<IProductSL>();
            _mockMapper = new Mock<IMapper>();
            _mockLogger = new Mock<ILogger<ProductController>>();
            //_mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockProductController = new ProductController
                (_mockProductSL.Object, _mockMapper.Object, _mockLogger.Object);
            

        }

        [TestMethod]
        public async Task Post_Add_Product()
        {
            //ARRAGEN
            var product = DTOProductStub.NewProduct;

            
            //ACT
           var response =  await _mockProductController.Post(product);
          

            //ASSERT
            Assert.IsInstanceOfType(response, typeof(ActionResult));
            Assert.IsNotNull(response);

        }



    }
}
