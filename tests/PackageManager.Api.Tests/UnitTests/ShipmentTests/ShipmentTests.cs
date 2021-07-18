using NUnit.Framework;
using ParcelManager.Core.Entities;
using ParcelManager.DTO.Shipments;
using System;

namespace PackageManager.API.Tests
{
    public class ShipmentTests
    {
        private Shipment _shipment;
        [SetUp]
        public void Setup()
        {
            _shipment = new Shipment
            {
                ShipmentNumber = "123-abcdef",
                Airport = ParcelManager.DTO.Enums.Airports.HEL,
                FlightDate = DateTime.MinValue,
                FlightNumber = "ab1234"
            };
        }

        [Test]
        public void ShouldEditShipmentSuccessfully()
        {
            var editDto = new ShipmentEditDto
            {
                FlightDate = DateTime.UtcNow
            };
            _shipment.EditShipment(editDto);

            Assert.AreEqual(editDto.FlightDate, _shipment.FlightDate);
        }

        [Test]
        public void ShouldFailEditingShipmentBecauseItIsFinalized()
        {
            _shipment.IsFinalized = true;
            var editDto = new ShipmentEditDto
            {
                FlightDate = DateTime.UtcNow
            };
            try
            {
                _shipment.EditShipment(editDto);
            }
            catch
            {

            }
            finally
            {
                Assert.AreNotEqual(editDto.FlightDate, _shipment.FlightDate);
            }
        }
    }
}