using AutoMapper;
using SmartLeopard.Api.MappingProfiles;

namespace SmartLeopard.Api
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(a =>
            {
                a.AddProfile<EntitiesProfile>(); 
            });
        }
    }
}