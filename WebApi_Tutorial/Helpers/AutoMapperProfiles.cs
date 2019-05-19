using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Tutorial.Dtos;

namespace WebApi_Tutorial.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<PersonForUpdateDto, Models.Person>();
        }
    }
}
