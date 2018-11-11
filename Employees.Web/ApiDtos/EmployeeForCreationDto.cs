using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.Web.ApiDtos
{
    public class EmployeeForCreationDto
    {
         public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public decimal Rate { get; set; }

        [Required]
        public DateTime EmploymentDate { get; set; }

        [Required]
        public ICollection<int> Jobs { get; set; }

       // [Required]
       // public string JobTitle { get; set; }

        public EmployeeForCreationDto()
        {
            Jobs = new Collection<int>();
        }
    }
}
