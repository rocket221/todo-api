using FluentValidation;
using TodoList.ViewModels;

namespace TodoList.Validators
{
    public class UpdateSheetValidator : AbstractValidator<UpdateSheetViewModel>
    {
        public UpdateSheetValidator()
        {
            RuleFor(list => list.Title).NotEmpty().Length(3, 250);
            RuleFor(list => list.Description).Length(3, 2500).When(list => !string.IsNullOrEmpty(list.Description));
            RuleFor(list => list.Id).NotEmpty();
        }
    }
}
