using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Employees.Logic.Dtos;
using Employees.Web.ApiDtos;

namespace Employees.Web.Mapper
{
    public class ApiMapperProfile : Profile
    {
        public ApiMapperProfile()
        {
            CreateMap<EmployeeForCreationDto, EmployeeDto>();
        }
    }
}
