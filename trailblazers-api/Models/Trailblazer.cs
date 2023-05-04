namespace trailblazers_api.Models
{
    public class Trailblazer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int ElementTypeId { get; set; }
        public int PathTypeId { get; set; }
        public int Rarity { get; set; }
        public int BaseHp { get; set; }
        public int BaseAtk { get; set; }
        public int BaseDef { get; set; }
        public int BaseSpeed { get; set; }
    }
}
