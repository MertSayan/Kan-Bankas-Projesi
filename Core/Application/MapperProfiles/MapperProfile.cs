using Application.Enums;
using Application.Features.Mediatr.Users.Commands;
using Application.Features.Mediatr.Users.Results;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MapperProfiles
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<User,CreateUserCommand>().ReverseMap()
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => Rol.Kullanıcı));
            CreateMap<User,UpdateUserCommand>().ReverseMap()
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => Rol.Kullanıcı));
            CreateMap<GetAllUserQueryResult, User>().ReverseMap()
                .ForMember(dest => dest.BloodTypeName, opt => opt.MapFrom(src => src.BloodType.BloodName))
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.RoleName));
            CreateMap<GetUserByIdQueryResult,User>().ReverseMap()
                .ForMember(dest => dest.BloodTypeName, opt => opt.MapFrom(src => src.BloodType.BloodName))
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.RoleName));
        }
    }
}
