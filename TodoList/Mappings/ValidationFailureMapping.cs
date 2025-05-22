using FluentValidation.Results;
using TodoList.Dtos;

namespace TodoList.Mappings
{
    public static class ValidationFailureMapping
    {
        public static ValidationFailureDto MapToResonse(this IEnumerable<ValidationFailure> validationFailures)
        {
            return new ValidationFailureDto
            {
                Errors = validationFailures.Select(x => new ValidationErrorViewModel
                {
                    PropertyName = x.PropertyName,
                    Message = x.ErrorMessage
                })
            };
        }
    }
}
