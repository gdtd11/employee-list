using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Employees.DataAccess.EntityFramework;
using Employees.DomainModels;
using Employees.Logic.Dtos;

namespace Employees.Logic.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<EmployeeDto> CreateEmployeeAsync(EmployeeDto employeeDto)
        {
            var employee = await _unitOfWork.Employees
                .GetEmployeeByNameAsync(employeeDto.FirstName, employeeDto.LastName);

            if (employee == null)
            {
                employee = _mapper.Map<Employee>(employeeDto);
                employee.CreationDate = DateTime.UtcNow;
                _unitOfWork.Employees.Add(employee);

                await _unitOfWork.SaveAsync();
                employeeDto.Id = employee.Id;
            }

            return employeeDto;
        }

        public async Task<bool> RemoveIfExist(int id)
        {
            var entity = await _unitOfWork.Employees.GetAsync(id);

            if (entity == null)
                return false;

            _unitOfWork.Employees.Remove(entity);

            await _unitOfWork.SaveAsync();

            return true;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployees()
        {
            var emps = await _unitOfWork.Employees.GetAllWithJobsAsync();

            return emps.Select(e => _mapper.Map<EmployeeDto>(e));
        }
    }
}
