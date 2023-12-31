﻿using AutoMapper;
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
            CreateMap<TrailblazerCreationDto, Trailblazer>()
                .ForPath(dto => dto.PathSR!.Id, src => src.MapFrom(src => src.PathId))
                .ForPath(dto => dto.Element!.Id, src => src.MapFrom(src => src.ElementId));
            CreateMap<Trailblazer, TrailblazerCreationDto>();
            CreateMap<TrailblazerUpdateDto, Trailblazer>();
        }
    }
}
