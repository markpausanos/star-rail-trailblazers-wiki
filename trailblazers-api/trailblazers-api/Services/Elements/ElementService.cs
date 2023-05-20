using trailblazers_api.Dtos.Elements;
using trailblazers_api.Models;
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

        public async Task<ElementDto> CreateElement(ElementCreationDto element)
        {
            var elementModel = new Element
            {
                Name = element.Name,
                Image = element.Image
            };
            elementModel.Id = await _repository.CreateElement(elementModel);
            return new ElementDto
            {
                Id = elementModel.Id,
                Name = elementModel.Name,
                Image = elementModel.Image
            };
        }

        public async Task<IEnumerable<ElementDto>> GetAllElements()
        {
            var elements = await _repository.GetAllElements();
            if (elements == null) return null;

            return elements.Select(element => new ElementDto
            {
                Id = element.Id,
                Name = element.Name,
                Image = element.Image
            });
        }

        public async Task<ElementDto> GetElementById(int id)
        {
            var elements = await _repository.GetAllElements();
            if (elements == null) return null;
            var element = elements.FirstOrDefault(x => x.Id == id);
            if (element == null) return null;

            return new ElementDto
            {
                Id = element.Id,
                Name = element.Name,
                Image = element.Image
            };
        }

        public async Task<bool> UpdateElement(ElementUpdateDto element)
        {
            var elementModel = new Element
            {
                Id = element.Id,
                Name = element.Name,
                Image = element.Image
            };
            return await _repository.UpdateElement(elementModel);
        }

        public async Task<bool> DeleteElement(int id)
        {
            return await _repository.DeleteElement(id);
        }
    }
}
