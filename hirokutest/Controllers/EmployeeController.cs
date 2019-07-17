﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hirokutest.Models;

namespace hirokutest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly WebApiDbContext _context;

        public EmployeeController(WebApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDetails>>> GetEmployeeDetails()
        {
            return await _context.EmployeeDetails.ToListAsync();
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDetails>> GetEmployeeDetails(int id)
        {
            var employeeDetails = await _context.EmployeeDetails.FindAsync(id);

            if (employeeDetails == null)
            {
                return NotFound();
            }
            return employeeDetails;
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeDetails(int id, EmployeeDetails employeeDetails)
        {
            if (id != employeeDetails.EmpId)
            {
                return BadRequest();
            }

            _context.Entry(employeeDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeDetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employee
        [HttpPost]
        public async Task<ActionResult<EmployeeDetails>> PostEmployeeDetails(EmployeeDetails employeeDetails)
        {
            _context.EmployeeDetails.Add(employeeDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeDetails", new { id = employeeDetails.EmpId }, employeeDetails);
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeDetails>> DeleteEmployeeDetails(int id)
        {
            var employeeDetails = await _context.EmployeeDetails.FindAsync(id);
            if (employeeDetails == null)
            {
                return NotFound();
            }
            _context.EmployeeDetails.Remove(employeeDetails);
            await _context.SaveChangesAsync();
            return employeeDetails;
        }

        private bool EmployeeDetailsExists(int id)
        {
            return _context.EmployeeDetails.Any(e => e.EmpId == id);
        }
    }
}
