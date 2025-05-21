using FluentValidation;
using TodoList.ViewModels;

namespace TodoList.Validators
{
    public class CreateItemValidator : AbstractValidator<CreateItemViewModel>
    {
        public CreateItemValidator()
        {
            RuleFor(item => item.Title).NotEmpty().Length(3, 250);
            RuleFor(item => item.Description).Length(3, 2500).When(item => !string.IsNullOrEmpty(item.Description));
            RuleFor(item => item.SheetId).NotEmpty();
        }
    }
}
