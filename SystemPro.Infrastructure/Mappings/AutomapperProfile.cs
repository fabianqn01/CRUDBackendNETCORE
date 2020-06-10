using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using SystemPro.Core.DTOs;
using SystemPro.Core.Entities;

namespace SystemPro.Infrastructure.Mappings
{
    public class AutomapperProfile: Profile 
    {
        public AutomapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

        }
    }
}
