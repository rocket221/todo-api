using FluentValidation.Results;

namespace TodoList.Validators
{
    public record ValidationFailed(IEnumerable<ValidationFailure> Errors)
    {
        public ValidationFailed(ValidationFailure error) : this(new[] {error})
        {
        }
    }
}
