namespace trailblazers_api.Models
{
    public class Trailblazer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public int Rarity { get; set; }
        public int BaseHp { get; set; }
        public int BaseAtk { get; set; }
        public int BaseDef { get; set; }
        public int BaseSpeed { get; set; }
        public Element? Element { get; set; }
        public PathSR? PathSR{ get; set; }
        public List<Eidolon> Eidolons { get; set; } = new List<Eidolon>();
        public List<Trace> Traces { get; set; } = new List<Trace>();
        public List<Skill> Skills { get; set; } = new List<Skill>();
    }
}
