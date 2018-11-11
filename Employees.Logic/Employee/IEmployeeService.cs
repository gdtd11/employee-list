using Employees.Logic.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Logic.Employees
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> CreateEmployeeAsync(EmployeeDto employeeDto);

        Task<bool> RemoveIfExist(int id);

        Task<IEnumerable<EmployeeDto>> GetAllEmployees();
    }
}
