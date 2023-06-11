using BidHeroApp.InputModels;
using FluentValidation;

namespace BidHeroApp.Validators
{
    public class BidInputModelValidator : AbstractValidator<BidInputModel>
    {
        public BidInputModelValidator()
        {
            RuleFor(x => x.Points)
                .GreaterThanOrEqualTo(1);
        }
    }
}
