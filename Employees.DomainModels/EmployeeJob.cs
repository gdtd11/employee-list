using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.DomainModels
{
    public class EmployeeJob
    {
        public int EmployeeId { get; set; }

        public int JobId { get; set; }

        public Employee Employee { get; set; }

        public Job Job { get; set; }
    }
}
