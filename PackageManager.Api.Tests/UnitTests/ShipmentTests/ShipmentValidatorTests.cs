using FluentValidation.TestHelper;
using NUnit.Framework;
using ParcelManager.Core.Entities;
using ParcelManager.Core.Validators;
using System;
using System.Collections.Generic;

namespace PackageManager.API.Tests
{
    public class ShipmentValidatorTests
    {
        private ShipmentValidator _validator;
        private Shipment _shipment;
        [SetUp]
        public void Setup()
        {
            _validator = new ShipmentValidator();
            _shipment = new Shipment
            {
                ShipmentNumber = "123-abcdef",
                FlightNumber = "ab1234",
                FlightDate = DateTime.MaxValue,
                Bags = new HashSet<Bag>
                {
                    new BagWithParcels
                    {
                        Parcels = new HashSet<Parcel>
                        {
                            new Parcel()
                        }
                    }
                }
            };
        }

        [Test]
        public void ShoulSucceedWhenShipmentHasDefaultValues()
        {
            var validationResult = _validator.TestValidate(_shipment);
            validationResult.ShouldNotHaveAnyValidationErrors();
        }

        [Test]
        public void ShouldFailWhenShipmentNumberFormatIsNotCorrect()
        {
            _shipment.ShipmentNumber = "a123-abcdef23";

            var validationResult = _validator.TestValidate(_shipment);
            validationResult.ShouldHaveValidationErrorFor(shipment => shipment.ShipmentNumber);
        }

        [Test]
        public void ShouldSucceedWhenShipmentNumberFormatIsCorrect()
        {
            _shipment.ShipmentNumber = "123-abcdef";

            var validationResult = _validator.TestValidate(_shipment);
            validationResult.ShouldNotHaveValidationErrorFor(shipment => shipment.ShipmentNumber);
        }

        [Test]
        public void ShouldFailWhenFlightNumberFormatIsNotCorrect()
        {
            _shipment.FlightNumber = "ab12342";

            var validationResult = _validator.TestValidate(_shipment);
            validationResult.ShouldHaveValidationErrorFor(shipment => shipment.FlightNumber);
        }

        [Test]
        public void ShouldSucceedWhenFlightNumberFormatIsCorrect()
        {
            _shipment.FlightNumber = "ab1234";

            var validationResult = _validator.TestValidate(_shipment);
            validationResult.ShouldNotHaveValidationErrorFor(shipment => shipment.FlightNumber);
        }

        [Test]
        public void ShouldFailWhenFlightDateIsPastAndShipmentIsFinalized()
        {
            _shipment.FlightDate = DateTime.MinValue;
            _shipment.IsFinalized = true;

            var validationResult = _validator.TestValidate(_shipment);
            validationResult.ShouldHaveValidationErrorFor(shipment => shipment.FlightDate);
        }

        [Test]
        public void ShouldSucceedWhenFlightDateIsPastAndShipmentIsNotFinalized()
        {
            _shipment.FlightDate = DateTime.MinValue;

            var validationResult = _validator.TestValidate(_shipment);
            validationResult.ShouldNotHaveValidationErrorFor(shipment => shipment.FlightDate);
        }

        [Test]
        public void ShouldSucceedWhenFlightDateIsInFutureAndShipmentIsFinalized()
        {
            _shipment.IsFinalized = true;

            var validationResult = _validator.TestValidate(_shipment);
            validationResult.ShouldNotHaveValidationErrorFor(shipment => shipment.FlightDate);
        }

        [Test]
        public void ShouldFailWhenShipmentHasNoBagsAndIsFinalized()
        {
            _shipment.Bags = new HashSet<Bag>();
            _shipment.IsFinalized = true;

            var validationResult = _validator.TestValidate(_shipment);
            validationResult.ShouldHaveValidationErrorFor(shipment => shipment.Bags);
        }

        [Test]
        public void ShouldFailWhenBagWithParcelIsEmptyAndShipmentIsFinalized()
        {
            _shipment.Bags = new HashSet<Bag>
            {
                new BagWithParcels
                {
                    Parcels = new HashSet<Parcel>
                    {
                    }
                }
            };
            _shipment.IsFinalized = true;

            var validationResult = _validator.TestValidate(_shipment);
            validationResult.ShouldHaveValidationErrorFor(shipment => shipment.Bags);
        }

        [Test]
        public void ShouldSucceedWhenBagHasParcelAndShipmentIsFinalized()
        {
            _shipment.IsFinalized = true;

            var validationResult = _validator.TestValidate(_shipment);
            validationResult.ShouldNotHaveValidationErrorFor(shipment => shipment.Bags);
        }
    }
}