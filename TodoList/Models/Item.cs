namespace TodoList.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UserId { get; set; }
        public DateTime? ClosedDate { get; set; }
        public Guid ItemsListId { get; set; }
        public ItemsList ItemsList { get; set; }
    }
}
