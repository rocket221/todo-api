using FluentValidation;
using TodoList.Models;

namespace TodoList.Validators
{
    public class ListValidator : AbstractValidator<ItemsList>
    {
        public ListValidator()
        {
            RuleFor(list => list.Title).NotEmpty().Length(3, 250);
            RuleFor(list => list.Description).Length(3, 2500).When(list => !string.IsNullOrEmpty(list.Description));
            RuleFor(list => list.UserId).NotEmpty();
            RuleFor(list => list.Id).NotEmpty();
        }
    }
}
