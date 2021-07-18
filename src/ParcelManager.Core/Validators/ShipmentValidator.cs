using FluentValidation;
using ParcelManager.Core.Entities;
using ParcelManager.DTO.Enums;
using System;
using System.Linq;

namespace ParcelManager.Core.Validators
{
    public class ShipmentValidator : AbstractValidator<Shipment>
    {
        private const string SHIPMENT_NUMBER_REGEX = "^[\\d|\\w]{3}-[\\d|\\w]{6}$";
        private const string FLIGHT_NUMBER_REGEX = "^\\w{2}\\d{4}$";

        public ShipmentValidator()
        {
            RuleFor(s => s.ShipmentNumber)
                .NotNull()
                .Matches(SHIPMENT_NUMBER_REGEX)
                .WithMessage($"Shipment number must match the following regular expression: {SHIPMENT_NUMBER_REGEX}!");
            RuleFor(s => s.Airport)
                .IsInEnum()
                .WithMessage($"Valid values for Airport: {string.Join(',', Enum.GetNames<Airports>())}");
            RuleFor(s => s.FlightNumber)
                .NotNull()
                .Matches(FLIGHT_NUMBER_REGEX)
                .WithMessage($"Flight number must match the following regular expression: {FLIGHT_NUMBER_REGEX}!");
            RuleFor(s => s.FlightDate)
                .Must((shipment, flightDate) =>
                    !shipment.IsFinalized
                    || flightDate > DateTime.Now)
                .WithMessage("Flight date must be in the future when finalizing shipment!");
            RuleFor(s => s.Bags)
                .Must((shipment, bags) =>
                    !shipment.IsFinalized
                    || bags.Any())
                .WithMessage("Finalized shipment can't be empty!");
            RuleFor(s => s.Bags)
                .Must((shipment, bags) =>
                    !shipment.IsFinalized
                    || bags.Where(b => b is BagWithParcels bag && bag is not null).All(b => (b as BagWithParcels)!.Parcels.Any()))
                .WithMessage("Finalized shipment can't contain empty bags!");

        }
    }
}
