using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CompanyAPI.Data;
using CompanyAPI.Models;
using CompanyAPI.Repositories;

namespace CompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IRepo<Project> projectRepo;
        private readonly CompanyContext _context;

        public ProjectsController(CompanyContext context, IRepo<Project> projectRepo)
        {
            _context = context;
            this.projectRepo = projectRepo;
        }

        // GET: api/Projects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            return await projectRepo.GetAll();
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            var project = await projectRepo.GetById(id);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }

        // PUT: api/Projects/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(int id, Project project)
        {
            if (id != project.ProjectNo)
            {
                return BadRequest();
            }

            var result = await projectRepo.Edit(project);
            if (result == -1)
            {
                if (!projectRepo.EntityExists(id))
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        // POST: api/Projects
        [HttpPost]
        public async Task<ActionResult<Project>> PostProject(Project project)
        {
            await projectRepo.Add(project);

            return CreatedAtAction("GetProject", new { id = project.ProjectNo }, project);
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await projectRepo.GetById(id);
            if (project == null)
            {
                return NotFound();
            }

            await projectRepo.Remove(project);

            return NoContent();
        }

    }
}
