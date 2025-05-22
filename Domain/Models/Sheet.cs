namespace Domain.Models
{
    public class Sheet
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }
        public List<Item>? Items { get; set; }
    }
}
