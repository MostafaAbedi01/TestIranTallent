using System.Text.Json.Serialization;

namespace testTalent
{
    public class Node
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Image { get; set; }
        public string? Link { get; set; }
        public int? ParentId { get; set; }
        public List<Node> Children { get; set; } = new List<Node>();
    }

}
