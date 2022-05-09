using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkManagement.Entity.Dto;
using WorkManagement.Entity.Models;

namespace WorkManagement.Entity.Mapper
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Department, DtoDepartment>().ReverseMap();
            CreateMap<Request, DtoRequest>().ReverseMap();
            CreateMap<Employee, DtoEmployee>().ReverseMap();
            CreateMap<Employee, DtoLoginEmployee>();
            CreateMap<DtoLogin, Employee>();
            CreateMap<DtoChangePassword, Employee>();

        }
    }
}
