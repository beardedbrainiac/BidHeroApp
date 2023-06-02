using BidHeroApp.InputModels;
using FluentValidation;

namespace BidHeroApp.Validators
{
    public class CategoryInputModelValidator : AbstractValidator<CategoryInputModel>
    {
        public CategoryInputModelValidator()
        {
            RuleFor(x => x).NotNull();

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .Length(2, 50);
        }
    }
}
