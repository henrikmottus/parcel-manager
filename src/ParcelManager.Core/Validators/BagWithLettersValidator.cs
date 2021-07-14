using FluentValidation;
using ParcelManager.Core.Entities;

namespace ParcelManager.Core.Validators
{
    public class BagWithLettersValidator : AbstractValidator<BagWithLetters>
    {
        public BagWithLettersValidator()
        {
            Include(new BagValidator());
            RuleFor(s => s.LetterCount)
                .GreaterThan(0);
            RuleFor(s => s.Weight).ScalePrecision(3, 10);
            RuleFor(s => s.Price).ScalePrecision(2, 10);
        }
    }
}
