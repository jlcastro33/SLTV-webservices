using AutoMapper;
using SmartLeopard.Web.MappingProfiles;

namespace SmartLeopard.Web
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(a =>
            {
                a.AddProfile<ApiModelsProfile>(); 
            });
        }
    }
}