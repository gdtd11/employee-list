using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.DataAccess.EntityFramework
{
    public class ContextFactory : IDesignTimeDbContextFactory<EmployeesContext>
    {
        public EmployeesContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EmployeesContext>();
            optionsBuilder.UseSqlServer(@"server=localhost; database=EmployeeDb; Integrated Security=SSPI");

            return new EmployeesContext(optionsBuilder.Options);
        }
    }
}
