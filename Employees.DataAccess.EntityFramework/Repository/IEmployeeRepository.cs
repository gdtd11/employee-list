using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Employees.DomainModels;

namespace Employees.DataAccess.EntityFramework
{
    public interface IEmployeeRepository: IRepository<Employee>
    {
        Task<Employee> GetEmployeeByNameAsync(string firstName, string lastName);

        Task<IEnumerable<Employee>> GetAllWithJobsAsync();
    }
}
