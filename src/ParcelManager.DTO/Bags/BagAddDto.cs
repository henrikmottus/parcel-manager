using ParcelManager.DTO.Enums;
using ParcelManager.DTO.Letters;

namespace ParcelManager.DTO.Bags
{
    public class BagAddDto
    {
        public int ShipmentId { get; set; }
        public string BagNumber { get; set; } = default!;
        public BagTypes BagType { get; set; }
        public LettersDto? Letters { get; set; }
    }
}