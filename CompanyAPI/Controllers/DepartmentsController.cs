using System;
using System.Collections.Generic;
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
    public class DepartmentsController : ControllerBase
    {
        private readonly IRepo<Department> departmentRepo;

        public DepartmentsController(IRepo<Department> departmentRepo)
        {

            this.departmentRepo = departmentRepo;
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            return await departmentRepo.GetAll();
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            var department = await departmentRepo.GetById(id);

            if (department == null)
            {
                return NotFound();
            }

            return department;
        }

        // PUT: api/Departments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, Department department)
        {
            if (id != department.DeptNo)
            {
                return BadRequest();
            }

            var result = await departmentRepo.Edit(department);
            if (result == -1)
            {
                if (!departmentRepo.EntityExists(id))
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        // POST: api/Departments
        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(Department department)
        {
            await departmentRepo.Add(department);
            return CreatedAtAction("GetDepartment", new { id = department.DeptNo }, department);
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await departmentRepo.GetById(id);
            if (department == null)
            {
                return NotFound();
            }

            await departmentRepo.Remove(department);

            return NoContent();
        }
    }
}
