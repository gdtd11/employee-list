using AutoMapper;
using Employees.DomainModels;
using Employees.Logic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Employees.Logic
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<EmployeeDto, Employee>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.Jobs, opt => opt.Ignore())
                .AfterMap((dto, e) =>
                {
                    e.Jobs.AddRange(dto.Jobs.Select(id => new EmployeeJob{JobId = id}));
                 });

            CreateMap<Employee, EmployeeDto>()
                .AfterMap((e, dto) =>
                {
                    var test = e.Jobs.Select(x => x.Job.Title);
                    dto.JobTitle = string.Join(" & ", test);
                });

            CreateMap<Job, JobDto>();
        }
    }
}
