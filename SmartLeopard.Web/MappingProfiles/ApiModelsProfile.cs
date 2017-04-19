using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using SmartLeopard.Models;
using SmartLeopard.Web.Models;

namespace SmartLeopard.Web.MappingProfiles
{
    public class ApiModelsProfile : Profile
    {
        public ApiModelsProfile()
        {
            CreateMap<RegisterViewModel, RegistryModel>();
        }
    }
}