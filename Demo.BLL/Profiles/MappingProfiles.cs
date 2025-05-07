using AutoMapper;
using Demo.BLL.Dto.EmployeeDto;
using Demo.DAL.Models.Emp_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Employee, CreatedEmpDto>()
                            .ForMember(dest => dest.HiringDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.HiringDate)))
                            .ForMember(dest => dest.EmployeeType, opt => opt.MapFrom(src => src.EmployeeType.ToString()))
                            .ReverseMap()
                            .ForMember(dest => dest.HiringDate, opt => opt.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)))
                            .ForMember(dest => dest.EmployeeType, opt => opt.MapFrom(src => Enum.Parse<EmployeeType>(src.EmployeeType)));

            CreateMap<UpdatedEmployeeDto, Employee>()
                .ForMember(dest => dest.HiringDate, opt => opt.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)))
                .ForMember(dest => dest.EmployeeType, opt => opt.MapFrom(src => Enum.Parse<EmployeeType>(src.EmployeeType)))
                .ReverseMap()
                .ForMember(dest => dest.HiringDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.HiringDate)))
                .ForMember(dest => dest.EmployeeType, opt => opt.MapFrom(src => src.EmployeeType.ToString()));

            CreateMap<Employee, EmployeeDetailsDto>()
                .ForMember(dest => dest.HiringDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.HiringDate)))
                .ForMember(dest => dest.EmployeeType, opt => opt.MapFrom(src => src.EmployeeType.ToString()));

            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.EmployeeType, opt => opt.MapFrom(src => src.EmployeeType.ToString()))
                .ReverseMap()
                .ForMember(dest => dest.EmployeeType, opt => opt.MapFrom(src => Enum.Parse<EmployeeType>(src.EmployeeType)));

        }
    }
}
