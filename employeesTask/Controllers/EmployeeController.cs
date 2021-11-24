using employeesTask.Data;
using employeesTask.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace employeesTask.Controllers
{
    [Route("employee")]
    // ss.com/employee
    [ApiController]
    public class ApiEmployeeController : ControllerBase
    {
        private readonly ApplicationContext _db;

        public ApiEmployeeController(ApplicationContext db)
        {
            _db = db;
        }



        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                return Ok(await _db.Employees.Select(a=> new{
                    a.Id,
                    Department = a.Department.Name_Ar,
                    a.Name_Ar,
                    a.Name_En,
                    a.Email,
                    a.Phone,
                    a.Salary,
                    a.Address,
                    }).ToListAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEmployeeById(int id) 
        {
            try
            {
                var x = await _db.Employees.FirstOrDefaultAsync(a => a.Id == id);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var x = _db.Employees.FirstOrDefault(a => a.Id == id);
                _db.Employees.Remove(x);
                await _db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> EditEmployee(EmployeeModel employee , int id)
        {
            try
            {
                var x = _db.Employees.FirstOrDefault(a => a.Id == id);
                x.Department_Id = employee.Department_Id;
                x.Name_Ar = employee.Name_Ar;
                x.Name_En = employee.Name_En;
                x.Email = employee.Email;
                x.Phone = employee.Phone;
                x.Address = employee.Address;
                await _db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeModel employee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Model Is Invalid");
                }
                _db.Employees.Add(employee);
                await _db.SaveChangesAsync();
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

    }
}
