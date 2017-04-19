using AutoMapper;
using SmartLeopard.Dal.Entities;
using SmartLeopard.Models;

namespace SmartLeopard.Api.MappingProfiles
{
    public class EntitiesProfile : Profile
    {
        public EntitiesProfile()
        {
            CreateMap< RegistryModel, User>();
        }
    }
}