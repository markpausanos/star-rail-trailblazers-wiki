using System.ComponentModel.DataAnnotations;

namespace trailblazers_api.Dtos.Builds
{
    public class BuildUpdateDto
    {
        [Required(ErrorMessage = "Id is a required field")]
        public int Id { get; set; }

        public string? Name { get; set; }
        public int? LightconeId { get; set; }

        public int? RelicId { get; set; }

        public int? OrnamentId { get; set; }
    }
}
