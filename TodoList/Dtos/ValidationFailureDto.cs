namespace TodoList.Dtos
{
    public class ValidationFailureDto
    {
        public required IEnumerable<ValidationErrorViewModel> Errors { get; set; }
    }

    public class ValidationErrorViewModel
    {
        public required string PropertyName { get; set; }
        public required string Message { get; set; }
    }
}
