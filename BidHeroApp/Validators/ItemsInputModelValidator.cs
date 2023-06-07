using BidHeroApp.InputModels;
using FluentValidation;

namespace BidHeroApp.Validators
{
    public class ItemsInputModelValidator : AbstractValidator<ItemsInputModel>
    {
        public ItemsInputModelValidator()
        {
            RuleFor(x => x).NotNull();

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .Length(2, 50);

            RuleFor(x => x.Quantity)
                .NotNull()
                .GreaterThanOrEqualTo(1);

            RuleFor(x => x.StartDate)
                .NotNull();

            RuleFor(x => x.EndDate)
                .NotNull();

            RuleFor(x => x.Category)
                .NotNull();
        }
    }
}
