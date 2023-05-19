namespace trailblazers_api.Dtos.Trailblazers
{
    public class TrailblazerUpdateDto
    {
        public string? Name { get; set; }
        public string? Image { get; set; }
        public int BaseHp { get; set; }
        public int BaseAtk { get; set; }
        public int BaseDef { get; set; }
        public int BaseSpeed { get; set; }
    }
}
