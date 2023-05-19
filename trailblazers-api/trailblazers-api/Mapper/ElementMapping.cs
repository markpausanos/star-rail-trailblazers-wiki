using AutoMapper;
using trailblazers_api.Dtos.Elements;
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
