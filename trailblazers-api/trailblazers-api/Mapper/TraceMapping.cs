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
            CreateMap<TraceCreationDto, Trace>();
            CreateMap<Trace, TraceDto>();
            CreateMap<TraceUpdateDto, Trace>();
        }
    }
}
