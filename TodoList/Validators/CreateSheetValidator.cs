using FluentValidation;
using TodoList.ViewModels;

namespace TodoList.Validators
{
    public class CreateSheetValidator : AbstractValidator<CreateSheetViewModel>
    {
        public CreateSheetValidator()
        {
            RuleFor(list => list.Title).NotEmpty().Length(3, 250);
            RuleFor(list => list.Description).Length(3, 2500).When(list => !string.IsNullOrEmpty(list.Description));
        }
    }
}
