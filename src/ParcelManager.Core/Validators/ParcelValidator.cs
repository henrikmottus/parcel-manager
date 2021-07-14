using FluentValidation;
using ParcelManager.Core.Entities;

namespace ParcelManager.Core.Validators
{
    public class ParcelValidator : AbstractValidator<Parcel>
    {
        private const string PARCEL_NUMBER_REGEX = "\\w{2}\\d{6}\\w{2}";

        public ParcelValidator()
        {
            RuleFor(s => s.ParcelNumber)
                .NotNull()
                .Matches(PARCEL_NUMBER_REGEX)
                .WithMessage($"Parcel number must match the following regular expression: {PARCEL_NUMBER_REGEX}!");
            RuleFor(s => s.RecipientName)
                .MaximumLength(100);
            RuleFor(p => p.DestinationCountry)
                .Length(2)
                .Must(p => p.ToUpperInvariant() == p)
                .WithMessage("Destination Country must be in upper case!");
            RuleFor(s => s.Weight).ScalePrecision(3, 10);
            RuleFor(s => s.Price).ScalePrecision(2, 10);
        }
    }
}
