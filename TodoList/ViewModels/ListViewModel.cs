namespace TodoList.ViewModels
{
    public class ListViewModel
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<ItemTitleViewModel>? Items { get; set; }
    }
}
