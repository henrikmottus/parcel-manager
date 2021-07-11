using ParcelManager.DTO.Bags;
using ParcelManager.DTO.Base;
using ParcelManager.DTO.Enums;
using System;

namespace ParcelManager.DTO.Shipments
{
    public class ShipmentDto : BaseDto
    {
        public string ShipmentNumber { get; set; } = default!;
        public Airports Airport { get; set; } = default!;
        public string FlightNumber { get; set; } = default!;
        public DateTime? FlightDate { get; set; } = default!;
        public bool IsFinalized { get; set; }

        public BagListDto Bags { get; set; } = default!;
    }
}
