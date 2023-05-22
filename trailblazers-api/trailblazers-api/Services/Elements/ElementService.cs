using AutoMapper;
using trailblazers_api.Dtos.Elements;
using trailblazers_api.Models;
using trailblazers_api.Repositories.Elements;

namespace trailblazers_api.Services.Elements
{
    public class ElementService : IElementService
    {
        private readonly IElementRepository _elementRepository;
        private readonly IMapper _mapper;

        public ElementService(IElementRepository repository, IMapper mapper)
        {
            _elementRepository = repository;
            _mapper = mapper;
        }

        public async Task<ElementDto?> CreateElement(ElementCreationDto newElement)
        {
            var elementToCreate = _mapper.Map<Element>(newElement);

            var newlyCreatedElement = await _elementRepository.GetElementById(await _elementRepository.CreateElement(elementToCreate));
            return _mapper.Map<ElementDto>(newlyCreatedElement);
        }

        public async Task<IEnumerable<ElementDto>> GetAllElements()
        {
            var elements = await _elementRepository.GetAllElements();

            return elements.Select(element => _mapper.Map<ElementDto>(element));
        }

        public async Task<ElementDto?> GetElementById(int id)
        {
            var element = await _elementRepository.GetElementById(id);

            return element == null ? null : _mapper.Map<ElementDto>(element);
        }
        public async Task<ElementDto?> GetElementByName(string name)
        {
            var element = await _elementRepository.GetElementByName(name);

            return element == null ? null : _mapper.Map<ElementDto>(element);
        }

        public async Task<bool> UpdateElement(int id, ElementUpdateDto updatedElement)
        {
            var elementToUpdate = _mapper.Map<Element>(updatedElement);
            elementToUpdate.Id = id;

            return await _elementRepository.UpdateElement(elementToUpdate);
        }

        public async Task<bool> DeleteElement(int id)
        {
            return await _elementRepository.DeleteElement(id);
        }
    }
}
