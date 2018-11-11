using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Employees.Logic.Dtos;
using Employees.Logic.Employees;
using Employees.Web.ApiDtos;
using Employees.Web.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
           var employees = await _employeeService.GetAllEmployees();

            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(EmployeeForCreationDto employeeDto)
        {
            if (employeeDto == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return new UnprocessableObjectResult(ModelState);

            var dto = await _employeeService.CreateEmployeeAsync(_mapper.Map<EmployeeDto>(employeeDto));

            if (dto.Id == 0)
            {
                return Conflict();
            }

            return Ok();
            //return CreatedAtRoute();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            if (!await _employeeService.RemoveIfExist(id))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}