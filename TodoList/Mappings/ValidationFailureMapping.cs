using FluentValidation.Results;
using TodoList.ViewModels;

namespace TodoList.Mappings
{
    public static class ValidationFailureMapping
    {
        public static ValidationFailureViewModel MapToResonse(this IEnumerable<ValidationFailure> validationFailures)
        {
            return new ValidationFailureViewModel
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
