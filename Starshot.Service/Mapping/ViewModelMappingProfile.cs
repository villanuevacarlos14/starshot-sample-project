using System;
using AutoMapper;
using Starshot.Data.Models;
using Starshot.DTO;

namespace Starshot.Service.Mapping
{
    public class ViewModelMappingProfile : Profile
    {
        public ViewModelMappingProfile()
        {
            CreateMap<UserDTO, User>();
            CreateMap<EmployeeDTO, Employee>();
            CreateMap<EmployeeAttendanceDTO, EmployeeAttendance>();

            CreateMap<User, UserDTO>();
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EmployeeAttendance, EmployeeAttendanceDTO>();
        }
    }
}
