using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Employees.Logic.Dtos;

namespace Employees.Logic
{
    public interface IJobService
    {
        Task<IEnumerable<JobDto>> GetAllJobs();
    }
}
