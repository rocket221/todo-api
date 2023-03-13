namespace TodoList.ViewModels
{
    public class CreateItemViewModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Guid ItemsListId { get; set; }
    }
}
