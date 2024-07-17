using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly FullStackDbContext _context;
        public EmployeeController(FullStackDbContext fullStackDbContext)
        {
            _context = fullStackDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            // async and task keyword abpove make the function asynchronous 

            var employees = await _context.Employees.ToListAsync();
            /*_context.Employees specifies the employees table*/
            return Ok(employees);
            // Ok indicates a status of 200 and we are passing the list of employees in that response 
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            employee.Id = Guid.NewGuid();

            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpGet]
        [Route("{id:guid}")]

        public async Task<IActionResult> GetEmployee([FromRoute] Guid id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x=> x.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);

        }

        [HttpPut]
        [Route("{id:guid}")]

        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, [FromBody] Employee employee)
        {
            var employeeUpdation = await _context.Employees.FindAsync(id);

            if (employeeUpdation == null)
            {
                return NotFound();
            }

            employeeUpdation.Name = employee.Name;
            employeeUpdation.Phone = employee.Phone;
            employeeUpdation.Email = employee.Email;
            employeeUpdation.Department = employee.Department;
            employeeUpdation.Salary = employee.Salary;

            await _context.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:guid}")]

        public async Task<IActionResult> deleteEmployee(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if(employee == null) {
                return NotFound(); 
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return Ok(employee);
        }
    }
}
