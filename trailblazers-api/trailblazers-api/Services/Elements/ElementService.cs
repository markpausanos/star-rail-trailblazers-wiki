﻿using trailblazers_api.Models;
using trailblazers_api.Repositories.Elements;

namespace trailblazers_api.Services.Elements
{
    public class ElementService : IElementService
    {
        private readonly IElementRepository _repository;

        public ElementService(IElementRepository repository)
        {
            _repository = repository;
        }

        public async Task<Element> CreateElement(Element element)
        {
            element.Id = await _repository.CreateElement(element);
            return element;
        }

        public async Task<IEnumerable<Element>> GetAllElements()
        {
            return await _repository.GetAllElements();
        }
    }
}
