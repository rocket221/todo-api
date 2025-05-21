namespace Domain.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UserId { get; set; }
        public DateTime? ClosedDate { get; set; }
        public int SheetId { get; set; }
        public Sheet? Sheet { get; set; }
    }
}
