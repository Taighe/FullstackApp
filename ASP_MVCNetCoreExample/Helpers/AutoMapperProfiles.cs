using ASP_MVCNetCoreExample.Dtos;
using ASP_MVCNetCoreExample.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MVCNetCoreExample.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserModel, MemberDto>();
            CreateMap<MovieRefModel, MovieRefDto>();
        }
    }
}
