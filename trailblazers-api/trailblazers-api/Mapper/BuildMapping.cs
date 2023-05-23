using AutoMapper;
using trailblazers_api.Dtos.Builds;
using trailblazers_api.Models;

namespace trailblazers_api.Mapper
{
    public class BuildMapping : Profile
    {
        public BuildMapping()
        {
            CreateMap<BuildCreationDto, Build>()
                .ForPath(dto => dto.User!.Id, src => src.MapFrom(src => src.UserId))
                .ForPath(dto => dto.Trailblazer!.Id, src => src.MapFrom(src => src.TrailblazerId))
                .ForPath(dto => dto.Lightcone!.Id, src => src.MapFrom(src => src.LightconeId))
                .ForPath(dto => dto.Relic!.Id, src => src.MapFrom(src => src.RelicId))
                .ForPath(dto => dto.Ornament!.Id, src => src.MapFrom(src => src.OrnamentId));
            CreateMap<Build, BuildDto>();
                //.ForMember(dto => dto.UserId, src => src.MapFrom(src => src.User!.Id))
                //.ForMember(dto => dto.TrailblazerId, src => src.MapFrom(src => src.Trailblazer!.Id))
                //.ForMember(dto => dto.LightconeId, src => src.MapFrom(src => src.Lightcone!.Id))
                //.ForMember(dto => dto.RelicId, src => src.MapFrom(src => src.Relic!.Id))
                //.ForMember(dto => dto.OrnamentId, src => src.MapFrom(src => src.Ornament!.Id));
            CreateMap<BuildUpdateDto, Build>()
                .ForPath(dto => dto.Lightcone!.Id, src => src.MapFrom(src => src.LightconeId))
                .ForPath(dto => dto.Relic!.Id, src => src.MapFrom(src => src.RelicId))
                .ForPath(dto => dto.Ornament!.Id, src => src.MapFrom(src => src.OrnamentId));
        }
    }
}
