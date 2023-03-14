using FluentValidation;
using TodoList.Models;

namespace TodoList.Validators
{
    public class ItemValidator : AbstractValidator<Item>
    {
        public ItemValidator()
        {
            RuleFor(item => item.Title).NotEmpty().Length(3,250);
            RuleFor(item => item.Description).Length(3,2500).When(item => !string.IsNullOrEmpty(item.Description));
            RuleFor(item => item.CreatedDate).NotNull();
            RuleFor(item => item.ClosedDate).GreaterThan(item => item.CreatedDate);
            RuleFor(item => item.UserId).NotEmpty();
            RuleFor(item => item.Id).NotEmpty();
        }
    }
}
