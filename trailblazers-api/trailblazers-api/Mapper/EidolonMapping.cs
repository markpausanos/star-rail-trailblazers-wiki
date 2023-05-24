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
            CreateMap<EidolonCreationDto, Eidolon>()
                .ForPath(dto => dto.Trailblazer!.Id, src => src.MapFrom(src => src.TrailblazerId));
            CreateMap<Eidolon, EidolonDto>();
            CreateMap<EidolonUpdateDto, Eidolon>();
        }
    }
}
