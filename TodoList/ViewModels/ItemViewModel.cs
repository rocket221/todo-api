namespace TodoList.ViewModels
{
    public class ItemViewModel
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UserId { get; set; }
        public DateTime? ClosedDate { get; set; }
        public Guid ItemsListId { get; set; }
    }
}
