using ParcelManager.DTO.Bags;
using ParcelManager.DTO.Base;
using ParcelManager.DTO.Enums;
using System;

namespace ParcelManager.DTO.Shipments
{
    public class ShipmentDto : BaseDto
    {
        public string ShipmentNumber { get; set; } = default!;
        public Airports? Airport { get; set; }
        public string? FlightNumber { get; set; }
        public DateTime? FlightDate { get; set; }
        public bool IsFinalized { get; set; }

        public BagListDto Bags { get; set; } = default!;
    }
}
