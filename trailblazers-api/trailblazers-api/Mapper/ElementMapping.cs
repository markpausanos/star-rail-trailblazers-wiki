using AutoMapper;
using trailblazers_api.DTOs.Elements;
using trailblazers_api.Models;

namespace trailblazers_api.Mapper
{
    public class ElementMapping : Profile
    {
        public ElementMapping()
        {
            CreateMap<Element, ElementDto>();
        }
    }
}
