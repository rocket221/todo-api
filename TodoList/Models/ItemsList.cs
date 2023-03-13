namespace TodoList.Models
{
    public class ItemsList
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Guid UserId { get; set; }
        public List<Item>? Items { get; set; }
    }
}
