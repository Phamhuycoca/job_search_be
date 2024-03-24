using AutoMapper;
using job_search_be.Domain.Dto.Auth;
using job_search_be.Domain.Dto.Permission;
using job_search_be.Domain.Dto.Role;
using job_search_be.Domain.Dto.User;
using job_search_be.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace job_search_be.Domain.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           CreateMap<Permission,PermissionDto>().ReverseMap();
           CreateMap<Permission,PermissionQuery>().ReverseMap();

           CreateMap<Role,RoleDto>().ReverseMap();
           CreateMap<Role,RoleQuery>().ReverseMap();

            CreateMap<User, LoginDto>().ReverseMap();
            CreateMap<Refresh_Token, RefreshTokenDto>().ReverseMap();

            CreateMap<User,UserQuery>().ReverseMap();
            CreateMap<User,UserDto>().ReverseMap();
        }
    }
}
