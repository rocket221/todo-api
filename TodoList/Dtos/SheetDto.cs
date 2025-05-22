namespace TodoList.Dtos
{
    public class SheetDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<ItemTitleDto>? Items { get; set; }
    }
}
