using AutoMapper;
using trailblazers_api.DTOs.Relics;
using trailblazers_api.Models;

namespace trailblazers_api.Mapper
{
    public class RelicMapping : Profile
    {
        public RelicMapping()
        {
            CreateMap<RelicCreationDto, Relic>();
            CreateMap<Relic, RelicDto>();
            CreateMap<RelicUpdateDto, Relic>();
        }
    }
}
