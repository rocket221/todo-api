namespace TodoList.Dtos
{
    public class CreateItemDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int SheetId { get; set; }
    }
}
