using ParcelManager.DTO.Enums;
using ParcelManager.DTO.Shipments;
using System;
using System.Collections.Generic;

namespace ParcelManager.Core.Entities
{
    public class Shipment : BaseEntity
    {
        public string ShipmentNumber { get; set; } = default!;
        public Airports Airport { get; set; } = default!;
        public string FlightNumber { get; set; } = default!;
        public DateTime? FlightDate { get; set; } = default!;
        public bool IsFinalized { get; set; }

        public ICollection<Bag> Bags { get; set; } = default!;

        public void EditShipment(ShipmentEditDto shipmentDto)
        {
            if (IsFinalized)
            {
                throw new ApplicationException("Shipment can't be edited after it has been finalized!");
            }

            FlightDate = shipmentDto.FlightDate;
        }

        public void FinalizeShipment()
        {
            if (IsFinalized)
            {
                throw new ApplicationException("Shipment has already been finalized!");
            }

            IsFinalized = true;
        }
    }
}