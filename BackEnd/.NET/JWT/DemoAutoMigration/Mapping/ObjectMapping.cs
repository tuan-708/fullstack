using AutoMapper;
using DemoAutoMigration.Common;
using DemoAutoMigration.DTO;
using DemoAutoMigration.Models;

namespace DemoAutoMigration.Mapping
{
    public class ObjectMapping : Profile
    {
        public ObjectMapping()
        {
            CreateMap<Job, JobDTO>()
                .ForMember(x => x.dateCreated, 
                src => src.MapFrom(src => src.dateCreated.ToString(GlobalStrings.FORMAT_DATE_TIME)))
                .ForMember(x => x.lastUpdate,
                src => src.MapFrom(src => src.lastUpdate.ToString(GlobalStrings.FORMAT_DATE_TIME)));
        }
    }
}
