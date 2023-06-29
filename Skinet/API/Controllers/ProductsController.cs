using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dto;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepo, IGenericRepository<ProductBrand> productBrandRepo, IGenericRepository<ProductType> productTypeRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
            _mapper = mapper;
        }

        [HttpGet("GetProducts")]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetProducts()
        {
            var spec = new ProductsWithTypesAndBrandsSpecification();
            var product = await _productRepo.ListAsync(spec);

            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(product));
        }

        [HttpGet("GetProductById/{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var prod = await _productRepo.GetEntityWithSpec(spec);
            return Ok(_mapper.Map<Product, ProductDto>(prod));
        }

        [HttpGet("GetBrand")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductsBrand()
        {
            var productBrand = await _productBrandRepo.ListAllAsync();
            return Ok(productBrand);
        }

        [HttpGet("GetBrandById/{id}")]
        public async Task<ActionResult<ProductBrand>> GetProductsBrandById(int id)
        {
            var prodBrand = await _productBrandRepo.GetByIdAsync(id);
            return Ok(prodBrand);
        }

        [HttpGet("GetProductType")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductsType()
        {
            var productType = await _productTypeRepo.ListAllAsync();
            return Ok(productType);
        }

        [HttpGet("GetProductTypeById/{id}")]
        public async Task<ActionResult<ProductType>> GetProductsTypeById(int id)
        {
            var prodType = await _productTypeRepo.GetByIdAsync(id);
            return Ok(prodType);
        }

        // GET: api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

