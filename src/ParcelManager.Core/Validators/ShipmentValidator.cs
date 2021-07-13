using FluentValidation;
using ParcelManager.Core.Entities;
using System.Linq;

namespace ParcelManager.Core.Validators
{
    public class ShipmentValidator : AbstractValidator<Shipment>
    {
        public ShipmentValidator()
        {
            RuleFor(s => s.ShipmentNumber)
                .NotNull()
                .Matches("[\\d|\\w]{3}-[\\d|\\w]{6}");
            RuleFor(s => s.Airport)
                .IsInEnum();
            RuleFor(s => s.FlightNumber)
                .Matches("\\w{2}\\d{4}");
            RuleFor(s => s.FlightDate)
                .Must((shipment, flightDate) =>
                    !shipment.IsFinalized
                    || flightDate > System.DateTime.Now)
                .WithMessage("Flight date must be in the future when finalizing shipment!");
            RuleFor(s => s.Bags)
                .Must((shipment, bags) =>
                    !shipment.IsFinalized
                    || bags.Any())
                .WithMessage("Finalized shipment can't be empty!");
            RuleFor(s => s.Bags)
                .Must((shipment, bags) =>
                    !shipment.IsFinalized
                    || bags.Any(b => b is BagWithParcels bagWithParcels && !bagWithParcels.Parcels.Any()))
                .WithMessage("Finalized shipment can't contain empty bags!");

        }
    }

    public class BagValidator : AbstractValidator<Bag>
    {
        public BagValidator()
        {
            RuleFor(s => s.BagNumber)
                .NotNull()
                .MaximumLength(15);
        }
    }

    public class BagWithLettersValidator : AbstractValidator<BagWithLetters>
    {
        public BagWithLettersValidator()
        {
            RuleFor(s => s.LetterCount)
                .GreaterThan(0);
            RuleFor(s => s.Weight).ScalePrecision(0, 3);
            RuleFor(s => s.Price).ScalePrecision(0, 2);
        }
    }

    public class BagWithParcelsValidator : AbstractValidator<BagWithParcels>
    {
        public BagWithParcelsValidator()
        {
            RuleFor(b => b.Parcels).Must(list => list.Any());
        }
    }

    public class ParcelValidator : AbstractValidator<Parcel>
    {
        public ParcelValidator()
        {
            RuleFor(s => s.ParcelNumber)
                .NotNull()
                .Matches("\\w{2}\\d{6}\\w{2}");
            RuleFor(s => s.RecipientName)
                .MaximumLength(100);
            RuleFor(p => p.DestinationCountry)
                .Length(2)
                .Must(p => p.ToUpperInvariant() == p);
            RuleFor(s => s.Weight).ScalePrecision(0, 3);
            RuleFor(s => s.Price).ScalePrecision(0, 2);
        }
    }
}
