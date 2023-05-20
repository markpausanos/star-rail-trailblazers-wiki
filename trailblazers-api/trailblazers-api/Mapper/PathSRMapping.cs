using AutoMapper;
using trailblazers_api.Dtos.Paths;
using trailblazers_api.Models;

namespace trailblazers_api.Mapper
{
    public class PathSRMapping : Profile
    {
        public PathSRMapping()
        {
            CreateMap<PathSRCreationDto, PathSR>();
            CreateMap<PathSR, PathSRDto>();
            CreateMap<PathSRUpdateDto, PathSR>();
        }
    }
}
