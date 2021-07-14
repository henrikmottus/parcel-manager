using ParcelManager.DTO.Enums;
using System;

namespace ParcelManager.DTO.Shipments
{
    public class ShipmentAddDto
    {
        public string ShipmentNumber { get; set; } = default!;
        public Airports? Airport { get; set; }
        public string? FlightNumber { get; set; }
        public DateTime? FlightDate { get; set; }
    }
}
