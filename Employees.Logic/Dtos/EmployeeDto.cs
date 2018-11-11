using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection.Metadata;
using System.Text;

namespace Employees.Logic.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime CreationDate { get; set; }

        public decimal Rate { get; set; }

        public DateTime EmploymentDate { get; set; }

        public ICollection<int> Jobs { get; set; }

        public string JobTitle { get; set; }

        public string FullName => $"{this.FirstName} {this.LastName}";

        public EmployeeDto()
        {
            Jobs = new Collection<int>();
        }
    }
}
