using AutoMapper;
using MES.Application.DTOS.Identiry;
using MES.Domain.Entitys.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Application.Mapping
{
    public  class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            //身份认证映射
            CreateMap<User,UserDto>().ReverseMap();
            CreateMap<User,CreateUserDto>().ReverseMap();
            CreateMap<User,UpdateUserDto>().ReverseMap();
            //CreateMap<User>
            CreateMap<Role,RoleDto>().ReverseMap();
            CreateMap<Role,CreateRoleDto>().ReverseMap();
            CreateMap<Role,UpdateRoleDto>().ReverseMap();

            CreateMap<Department,DepartmentDto>().ReverseMap();
            CreateMap<Permission,PermissionDto>().ReverseMap();
        }
    }
}
