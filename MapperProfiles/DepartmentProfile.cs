using AutoMapper;
using KazanNeftApi.DTO;
using KazanNeftApi.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KazanNeftApi.MapperProfiles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Departments, DepartmentDTO>()
                .ReverseMap();
        }
    }
}
