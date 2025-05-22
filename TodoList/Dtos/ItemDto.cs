namespace TodoList.Dtos
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
        public DateTime? ClosedDate { get; set; }
        public int SheetId { get; set; }
    }
}
