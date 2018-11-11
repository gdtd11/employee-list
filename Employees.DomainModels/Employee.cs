using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Employees.DomainModels
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime CreationDate { get; set; }

        public decimal Rate { get; set; }

        public DateTime EmploymentDate { get; set; }

        public List<EmployeeJob> Jobs { get; set; }

        public Employee()
        {
            this.Jobs = new List<EmployeeJob>();
        }

    }
}
