namespace TodoList.Dtos
{
    public class UpdateItemDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? ClosedDate { get; set; }
    }
}
