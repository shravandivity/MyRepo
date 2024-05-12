using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        List<Product> lst = new List<Product>();
        public TestController()
        {
            lst.AddRange(
                new Product[]
                { 
                new Product { ID = 1, ProductName = "Booksss", ProductCategory = "Fiction", ProductPrice = "200" },
                new Product { ID = 2, ProductName = "Pen", ProductCategory = "InkPen", ProductPrice = "50" },
                new Product { ID = 3, ProductName = "Cover", ProductCategory = "LargeBook", ProductPrice = "100" },
                new Product { ID = 4, ProductName = "Sweet", ProductCategory = "MilkProduct", ProductPrice = "500" },
                new Product { ID = 5, ProductName = "CHips", ProductCategory = "Potato", ProductPrice = "400" }
                });
        }

        // GET: api/values
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(lst);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

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

