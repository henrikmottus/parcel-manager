using ParcelManager.DTO.Enums;
using System;

namespace ParcelManager.DTO.Shipments
{
    public class ShipmentAddDto
    {
        public string ShipmentNumber { get; set; } = default!;
        public Airports Airport { get; set; } = default!;
        public string FlightNumber { get; set; } = default!;
        public DateTime? FlightDate { get; set; } = default!;
    }
}
