using AutoMapper;
using trailblazers_api.Dtos.Lightcones;
using trailblazers_api.Models;

namespace trailblazers_api.Mapper
{
    public class LightconeMapping : Profile
    {
        public LightconeMapping()
        {
            CreateMap<LightconeCreationDto, Lightcone>()
                .ForPath(dto => dto.PathSR!.Id, src => src.MapFrom(src => src.PathId));
            CreateMap<Lightcone, LightconeCreationDto>();
            CreateMap<Lightcone, LightconeDto>();
            CreateMap<LightconeUpdateDto, Lightcone>();
        }
    }
}
