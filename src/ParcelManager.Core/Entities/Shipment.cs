using ParcelManager.Core.Enums;
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

        public ICollection<Bag> Bags { get; set; } = default!;
    }
}