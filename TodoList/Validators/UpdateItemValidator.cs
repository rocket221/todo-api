using FluentValidation;
using TodoList.Dtos;

namespace TodoList.Validators
{
    public class UpdateItemValidator : AbstractValidator<UpdateItemDto>
    {
        public UpdateItemValidator()
        {
            RuleFor(item => item.Title).NotEmpty().Length(3, 250);
            RuleFor(item => item.Description).Length(3, 2500).When(item => !string.IsNullOrEmpty(item.Description));
            RuleFor(item => item.ClosedDate).Must(BeUtc).WithMessage("Date must be in UTC format.");

        }

        private bool BeUtc(DateTime? date)
        {
            return !date.HasValue || date.Value.Kind == DateTimeKind.Utc;
        }
    }
}
