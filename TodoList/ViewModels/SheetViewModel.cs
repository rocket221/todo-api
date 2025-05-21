namespace TodoList.ViewModels
{
    public class SheetViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<ItemTitleViewModel>? Items { get; set; }
    }
}
