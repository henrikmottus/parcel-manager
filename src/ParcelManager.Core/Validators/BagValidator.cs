using FluentValidation;
using ParcelManager.Core.Entities;

namespace ParcelManager.Core.Validators
{
    public class BagValidator : AbstractValidator<Bag>
    {
        public BagValidator()
        {
            RuleFor(s => s.BagNumber)
                .NotNull()
                .MaximumLength(15);
        }
    }
}
