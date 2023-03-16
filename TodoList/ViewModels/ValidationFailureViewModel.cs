namespace TodoList.ViewModels
{
    public class ValidationFailureViewModel
    {
        public IEnumerable<ValidationErrorViewModel> Errors { get; set; }
    }

    public class ValidationErrorViewModel
    {
        public string PropertyName { get; set; }
        public string Message { get; set; }
    }
}
