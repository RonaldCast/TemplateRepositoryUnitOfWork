using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DomainModel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Contracts;
using TemplateUnitWorkRepository.DTO;

namespace TemplateUnitWorkRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductSL _slProduct; 
        private readonly IMapper _mapper;
        public ProductController(IProductSL product, IMapper mapper)
        {
            _slProduct = product;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<DTOProduct> Get()
        {
            var products = _slProduct.GetProducts();
            return _mapper.Map<IEnumerable<Product>, IEnumerable<DTOProduct>>(products);
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public IEnumerable<DTOProduct> Get(int userId)
        {
            var products = _slProduct.GetUserProducts(userId);
            return _mapper.Map<IEnumerable<Product>, IEnumerable<DTOProduct>>(products);
        }

        // POST: api/Product
        [HttpPost]
        public ActionResult<DTOProduct> Post([FromBody] DTOProduct product)
        {

            var newProduct = _mapper.Map<Product>(product);
            _slProduct.AddProduct(newProduct);

            return Ok(new { message = "Hola" });

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}