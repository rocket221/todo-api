using FluentValidation;
using TodoList.ViewModels;

namespace TodoList.Validators
{
    public class UpdateItemValidator : AbstractValidator<UpdateItemViewModel>
    {
        public UpdateItemValidator()
        {
            RuleFor(item => item.Title).NotEmpty().Length(3, 250);
            RuleFor(item => item.Description).Length(3, 2500).When(item => !string.IsNullOrEmpty(item.Description));
        }
    }
}
