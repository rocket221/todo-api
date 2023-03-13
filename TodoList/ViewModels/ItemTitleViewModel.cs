namespace TodoList.ViewModels
{
    public class ItemTitleViewModel
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public bool IsClosed { get; set; }
    }
}
