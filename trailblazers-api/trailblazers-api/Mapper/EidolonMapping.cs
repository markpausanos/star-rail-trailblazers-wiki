using AutoMapper;
using trailblazers_api.Dtos.Eidolons;
using trailblazers_api.Models;

namespace trailblazers_api.Mapper
{
    public class EidolonMapping : Profile
    {
        public EidolonMapping()
        {
            CreateMap<Eidolon, EidolonTrailblazerDto>();
        }
    }
}
