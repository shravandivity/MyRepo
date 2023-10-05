using System;
using System.Collections.Generic;
using System.Globalization;
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
    public class ProjectsController : Controller
    {

        private readonly ApplicationDbContext _dbContext;
        public ProjectsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: /<controller>/
        [HttpGet]
        //[Route("api/projects")]
        public async Task<IActionResult> Get()
        {
            //var projects = await _dbContext.Projects.ToListAsync();
            //List<ProjectView> pv = new List<ProjectView>();
            //foreach (Project p in projects)
            //{
            //    pv.Add(new ProjectView { ProjectID = p.ProjectID, ProjectName = p.ProjectName, DateOfStart = p.DateOfStart.ToString("dd/MM/yyyy"), TeamSize = p.TeamSize });
            //}
            //return pv;
            List<ProjectView> pView = new List<ProjectView>();
            var projects = await _dbContext.Projects.Include("ClientLocation").ToListAsync();
            foreach(var p in projects)
            {
                pView.Add(new ProjectView { ProjectID = p.ProjectID, ProjectName = p.ProjectName, DateOfStart = p.DateOfStart, TeamSize = p.TeamSize, Active = p.Active, Status = p.Status, ClientLocation = p.ClientLocation, ClientLocationId = p.ClientLocationId });
            }
            return Ok(pView);
        }

        [HttpGet("GetProjectByName/{projectname}")]
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
                var pv = new ProjectView { ProjectID = p.ProjectID, ProjectName = p.ProjectName, DateOfStart = p.DateOfStart, TeamSize = p.TeamSize, Active = p.Active, Status = p.Status, ClientLocation = p.ClientLocation, ClientLocationId = p.ClientLocationId } ;

                return Ok(pv);
            }
            else
                return BadRequest();
        }

        [HttpGet("GetProjectById/{id}")]
        //[Route("api/projects")]
        public async Task<IActionResult> Get(int id)
        {
            //var projects = await _dbContext.Projects.ToListAsync();
            //List<ProjectView> pv = new List<ProjectView>();
            //foreach (Project p in projects)
            //{
            //    pv.Add(new ProjectView { ProjectID = p.ProjectID, ProjectName = p.ProjectName, DateOfStart = p.DateOfStart.ToString("dd/MM/yyyy"), TeamSize = p.TeamSize });
            //}
            //return pv;

            var p = await _dbContext.Projects.Include("ClientLocation").Where(p => p.ProjectID == 34).FirstOrDefaultAsync();

            if (p != null)
            {
                var pv = new ProjectView { ProjectID = p.ProjectID, ProjectName = p.ProjectName, DateOfStart = p.DateOfStart, TeamSize = p.TeamSize, Active = p.Active, Status = p.Status, ClientLocation = p.ClientLocation, ClientLocationId = p.ClientLocationId };

                return Ok(pv);
            }
            else
                return BadRequest();
        }

        // GET api/values/5
        [HttpGet("Search/{searchby}/{searchtext}")]
        public async Task<IActionResult> Search(string searchby, string searchtext)
        {
            List<Project> projects;
            List<ProjectView> pView = new List<ProjectView>();
            switch (searchby.ToLower())
            {
                case "projectid":
                    projects = await _dbContext.Projects.Include("ClientLocation").Where(p => p.ProjectID.ToString().Contains(searchtext)).ToListAsync();
                    break;
                case "projectname":
                    projects = await _dbContext.Projects.Include("ClientLocation").Where(p => p.ProjectName.Contains(searchtext)).ToListAsync();
                    break;
                case "dateofstart":
                    projects = await _dbContext.Projects.Include("ClientLocation").Where(p => p.DateOfStart.ToString().Contains(searchtext)).ToListAsync();
                    break;
                case "teamsize":
                    projects = await _dbContext.Projects.Include("ClientLocation").Where(p => p.TeamSize.ToString().Contains(searchtext)).ToListAsync();
                    break;
                default:
                    projects = await _dbContext.Projects.Include("ClientLocation").ToListAsync();
                    break;
            }
            if (projects != null)
            {
                foreach (var p in projects)
                {
                    pView.Add(new ProjectView { ProjectID = p.ProjectID, ProjectName = p.ProjectName, DateOfStart = p.DateOfStart, TeamSize = p.TeamSize, Active = p.Active, Status = p.Status, ClientLocation = p.ClientLocation, ClientLocationId = p.ClientLocationId });
                }
                return Ok(pView);
            }   
            else
                return BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Project project)
        {
            //if (ModelState.IsValid)
            //{
            //    var project = new Project { ProjectName = pv.ProjectName, DateOfStart = DateTime.ParseExact(pv.DateOfStart, "yyyy-MM-dd", CultureInfo.InvariantCulture), TeamSize = pv.TeamSize };
            //    await _dbContext.AddAsync(project);
            //    await _dbContext.SaveChangesAsync();
            //    pv.ProjectID = project.ProjectID;
            //    //var projvw = new ProjectView { ProjectID = project.ProjectID, ProjectName = project.ProjectName, DateOfStart = project.DateOfStart.ToString("dd/MM/yyyy"), TeamSize = project.TeamSize };
            //    return Ok(pv);
            //}
            //else
            //{
            //    return BadRequest();
            //}

            if (ModelState.IsValid)
            {
                project.ClientLocation = null;
                await _dbContext.AddAsync(project);
                await _dbContext.SaveChangesAsync();
                Project existingProject = await _dbContext.Projects.Include("ClientLocation").Where(p => p.ProjectID == project.ProjectID).FirstOrDefaultAsync();
                return Ok(new ProjectView { ProjectID = existingProject.ProjectID, ProjectName = existingProject.ProjectName, DateOfStart = existingProject.DateOfStart, TeamSize = existingProject.TeamSize, Active = existingProject.Active, Status = existingProject.Status, ClientLocation = existingProject.ClientLocation, ClientLocationId = existingProject.ClientLocationId });
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Project project)
        {
            if (ModelState.IsValid)
            {
                var prj = await _dbContext.Projects.Include("ClientLocation").Where(p => p.ProjectID == project.ProjectID).FirstOrDefaultAsync();
                if (prj != null)
                {
                    prj.ProjectName = project.ProjectName;
                    prj.DateOfStart = project.DateOfStart;
                    prj.TeamSize = project.TeamSize;
                    prj.Active = project.Active;
                    prj.ClientLocationId = project.ClientLocationId;
                    prj.Status = project.Status;
                    //prj.ClientLocation = null;
                    _dbContext.Update(prj);
                    await _dbContext.SaveChangesAsync();
                    Project existingProject = await _dbContext.Projects.Include("ClientLocation").Where(p => p.ProjectID == project.ProjectID).FirstOrDefaultAsync();
                    return Ok(new ProjectView { ProjectID = existingProject.ProjectID, ProjectName = existingProject.ProjectName, DateOfStart = existingProject.DateOfStart, TeamSize = existingProject.TeamSize, Active = existingProject.Active, Status = existingProject.Status, ClientLocation = existingProject.ClientLocation, ClientLocationId = existingProject.ClientLocationId });
                    
                }
                else
                    return BadRequest();
            }
            else
                return BadRequest();
        }

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

