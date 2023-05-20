namespace trailblazers_api.Dtos.Lightcones
{
    public class LightconeUpdateDto
    {

        public string? Title { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int? Rarity { get; set; }
        public int? BaseHp { get; set; }
        public int? BaseAtk { get; set; }
        public int? BaseDef { get; set; }
    }
}
