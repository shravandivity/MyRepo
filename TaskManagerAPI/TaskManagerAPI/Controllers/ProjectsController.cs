using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;
using TaskManagerAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagerAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public ProjectsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<List<Project>>> Get()
        {
            return await _dbContext.Projects.ToListAsync();
        }

        // GET api/values/5
        [HttpGet("Search/{searchby}/{searchtext}")]
        public async Task<ActionResult<Project>> Search(string searchby, string searchtext)
        {
            List<Project> projects;
            switch(searchby.ToLower())
            {
                case "projectid":
                    projects = await _dbContext.Projects.Where(p => p.ProjectID.ToString().Contains(searchtext)).ToListAsync();
                    break;
                case "projectname":
                    projects = await _dbContext.Projects.Where(p => p.ProjectName.Contains(searchtext)).ToListAsync();
                    break;
                case "dateofstart":
                    projects = await _dbContext.Projects.Where(p => p.DateOfStart.ToString().Contains(searchtext)).ToListAsync();
                    break;
                case "teamsize":
                    projects = await _dbContext.Projects.Where(p => p.TeamSize.ToString().Contains(searchtext)).ToListAsync();
                    break;
                default:
                    projects = await _dbContext.Projects.ToListAsync();
                    break;
            }
            if (projects != null)
                return Ok(projects);
            else
                return BadRequest();   
        }

        [HttpGet("{projectname}")]
        //[Route("api/projects")]
        public async Task<IActionResult> Get(string projectname)
        {
            //var projects = await _dbContext.Projects.ToListAsync();
            //List<ProjectView> pv = new List<ProjectView>();
            //foreach (Project p in projects)
            //{
            //    pv.Add(new ProjectView { ProjectID = p.ProjectID, ProjectName = p.ProjectName, DateOfStart = p.DateOfStart.ToString("dd/MM/yyyy"), TeamSize = p.TeamSize });
            //}
            //return pv;

            var p = await _dbContext.Projects.Include("ClientLocation").Where(p => p.ProjectName == projectname).FirstOrDefaultAsync();

            if (p != null)
            {
                var pv = new ProjectView { ProjectID = p.ProjectID, ProjectName = p.ProjectName, DateOfStart = p.DateOfStart, TeamSize = p.TeamSize, Active = p.Active, Status = p.Status, ClientLocation = p.ClientLocation, ClientLocationId = p.ClientLocation.ClientLocationId };

                return Ok(pv);
            }
            else
                return BadRequest();
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Project>> Post([FromBody]Project project)
        {
            if(ModelState.IsValid)
            {
                await _dbContext.AddAsync(project);
                await _dbContext.SaveChangesAsync();
                return Ok(project);
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<ActionResult<Project>> Put([FromBody]Project project)
        {
            if (ModelState.IsValid)
            {
                var prj = await _dbContext.Projects.Where(p => p.ProjectID == project.ProjectID).FirstOrDefaultAsync();
                if (prj != null)
                {
                    prj.ProjectName = project.ProjectName;
                    prj.DateOfStart = project.DateOfStart;
                    prj.TeamSize = project.TeamSize;
                    _dbContext.Update(prj);
                    await _dbContext.SaveChangesAsync();
                    return Ok(prj);
                }
                else
                    return BadRequest();
            }
            else
                return BadRequest();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var prj = await _dbContext.Projects.Where(p => p.ProjectID == id).FirstOrDefaultAsync();
            if (prj != null)
            {
                _dbContext.Remove(prj);
                await _dbContext.SaveChangesAsync();
                return Ok(id);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

