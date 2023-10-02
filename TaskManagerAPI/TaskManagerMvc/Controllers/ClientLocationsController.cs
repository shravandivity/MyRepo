using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagerMvc.Data;
using TaskManagerMvc.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagerMvc.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ClientLocationsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ClientLocationsController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        // GET: /<controller>/
        [HttpGet]
        public async Task<ActionResult<List<ClientLocation>>> Get()
        {
            return await _dbContext.ClientLocations.ToListAsync();
        }
    }
}

