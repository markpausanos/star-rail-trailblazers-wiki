using AutoMapper;
using trailblazers_api.Dtos.Ornaments;
using trailblazers_api.Models;

namespace trailblazers_api.Mapper
{
    public class OrnamentMapping : Profile
    {
        public OrnamentMapping()
        {
            CreateMap<OrnamentCreationDto, Ornament>();
            CreateMap<Ornament, OrnamentDto>();
            CreateMap<OrnamentUpdateDto, Ornament>();
        }
    }
}
