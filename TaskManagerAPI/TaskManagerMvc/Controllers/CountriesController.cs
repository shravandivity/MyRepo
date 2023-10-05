using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagerMvc.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagerMvc.Controllers
{
    [Route("api/[controller]")]
    public class CountriesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CountriesController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        // GET: /<controller>/
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var countries = await _dbContext.Countries.OrderBy(temp => temp.CountryName).ToListAsync();
            return Ok(countries);
        }
    }
}

