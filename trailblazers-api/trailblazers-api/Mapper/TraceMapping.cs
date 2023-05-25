using AutoMapper;
using trailblazers_api.Dtos.Traces;
using trailblazers_api.Models;

namespace trailblazers_api.Mapper
{
    public class TraceMapping : Profile
    {
        public TraceMapping()
        {
            CreateMap<Trace, TraceTrailblazerDto>();
            CreateMap<TraceCreationDto, Trace>()
                .ForPath(dto => dto.Trailblazer!.Id, src => src.MapFrom(src => src.TrailblazerId));
            CreateMap<Trace, TraceDto>();
            CreateMap<TraceUpdateDto, Trace>();
        }
    }
}
