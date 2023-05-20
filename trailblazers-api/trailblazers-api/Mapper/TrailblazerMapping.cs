using AutoMapper;
using trailblazers_api.Dtos.Trailblazers;
using trailblazers_api.Models;

namespace trailblazers_api.Mapper
{
    public class TrailblazerMapping : Profile
    {
        public TrailblazerMapping()
        {
            CreateMap<Trailblazer, TrailblazerIdNameDto>();
            CreateMap<Trailblazer, TrailblazerDto>();
            CreateMap<TrailblazerCreationDto, Trailblazer>();
            CreateMap<Trailblazer, TrailblazerCreationDto>();
        }
    }
}
