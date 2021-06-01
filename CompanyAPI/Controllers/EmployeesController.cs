using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CompanyAPI.Data;
using CompanyAPI.Models;
using Microsoft.AspNetCore.Authorization;
using CompanyAPI.Repositories;

namespace CompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IRepo<Employee> employeesRepo;

        public EmployeesController(IRepo<Employee> employeesRepo)
        {
            this.employeesRepo = employeesRepo;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await employeesRepo.GetAll();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await employeesRepo.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmpNo)
            {
                return BadRequest();
            }

            var result = await employeesRepo.Edit(employee);

            if (result == -1)
            {
                if (!employeesRepo.EntityExists(id))
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        // POST: api/Employees
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            await employeesRepo.Add(employee);

            return CreatedAtAction("GetEmployee", new { id = employee.EmpNo }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await employeesRepo.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }

            await employeesRepo.Remove(employee);

            return NoContent();
        }


    }
}
