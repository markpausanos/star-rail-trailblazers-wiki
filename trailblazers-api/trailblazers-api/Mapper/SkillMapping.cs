﻿using AutoMapper;
using trailblazers_api.Dtos.Trailblazers;
using trailblazers_api.DTOs.Skills;
using trailblazers_api.Models;

namespace trailblazers_api.Mapper
{
    public class SkillMapping : Profile
    {
        public SkillMapping()
        {
            CreateMap<SkillCreationDto, Skill>()
                .ForPath(dto => dto.Trailblazer!.Id, src => src.MapFrom(src => src.TrailblazerId));
            CreateMap<Skill, SkillDto>()
                .ForMember(dto => dto.Trailblazer, src => src.MapFrom(src => new TrailblazerShowDto
                {
                    Id = src.Trailblazer!.Id,
                    Name = src.Trailblazer.Name
                }));
        }
    }
}
