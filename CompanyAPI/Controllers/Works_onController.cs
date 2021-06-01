using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CompanyAPI.Data;
using CompanyAPI.Models;
using CompanyAPI.Repositories;

namespace CompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Works_onController : ControllerBase
    {
        private readonly IWorkRepo worksRepo;

        public Works_onController(IWorkRepo worksRepo)
        {
            this.worksRepo = worksRepo;
        }

        // GET: api/Works_on
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkViewModel>>> GetWorks_on()
        {
            List<WorkViewModel> Works = new List<WorkViewModel>();
            var oldWorks = await worksRepo.GetAll(true);
            foreach (var work in oldWorks)
            {
                Works.Add(new WorkViewModel
                {
                    ProjectNo = work.ProjectNo,
                    EmpNo = work.EmpNo,
                    Enter_Date = work.Enter_Date,
                    Job = work.Job,
                    ProjectName = work.Project.ProjectName,
                    EmployeeName = work.Employee.Fname
                });
            }
            return Works;
        }

        // GET: api/Works_on/5
        [HttpGet("{id}/{second_id}")]
        public async Task<ActionResult<WorkViewModel>> GetWorks_on(int id, int second_id)
        {
            var work = await worksRepo.GetWorkById(id, second_id);

            if (work == null)
            {
                return NotFound();
            }

            WorkViewModel result = new WorkViewModel
            {
                ProjectNo = work.ProjectNo,
                EmpNo = work.EmpNo,
                Enter_Date = work.Enter_Date,
                Job = work.Job,
                ProjectName = work.Project.ProjectName,
                EmployeeName = work.Employee.Fname
            };

            return result;
        }

        // PUT: api/Works_on/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}/{second_id}")]
        public async Task<IActionResult> PutWorks_on(int id, int second_id, Works_on works_on)
        {
            if (id != works_on.EmpNo || second_id != works_on.ProjectNo)
            {
                return BadRequest();
            }

            var result = await worksRepo.Edit(works_on);
            if (result == -1)
            {
                if (!worksRepo.EntityExists(id, second_id))
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        // POST: api/Works_on
        [HttpPost]
        public async Task<ActionResult<Works_on>> PostWorks_on(Works_on works_on)
        {

            try
            {
                await worksRepo.Add(works_on);
            }
            catch
            {
                return Conflict();
            }

            return CreatedAtAction("GetWorks_on", new { id = works_on.EmpNo }, works_on);
        }

        // DELETE: api/Works_on/5
        [HttpDelete("{id}/{second_id}")]
        public async Task<IActionResult> DeleteWorks_on(int id, int second_id)
        {
            var works_on = await worksRepo.GetWorkById(id, second_id);
            if (works_on == null)
            {
                return NotFound();
            }

            await worksRepo.Remove(works_on);

            return NoContent();
        }
    }
}
