using BidHeroApp.InputModels;
using FluentValidation;

namespace BidHeroApp.Validators
{
    public class ItemInputModelValidator : AbstractValidator<ItemInputModel>
    {
        public ItemInputModelValidator()
        {
            RuleFor(x => x).NotNull();

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .Length(2, 50);

            RuleFor(x => x.Code)
                .NotNull()
                .NotEmpty()
                .Length(2, 50);

            RuleFor(x => x.StartDate)
                .NotNull();

            RuleFor(x => x.EndDate)
                .NotNull();

            RuleFor(x => x.Category)
                .NotNull()
                .GreaterThanOrEqualTo(1);

            RuleFor(x => x.Image)
                .NotNull();
        }
    }
}
