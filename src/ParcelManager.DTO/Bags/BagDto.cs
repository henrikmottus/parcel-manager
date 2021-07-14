using ParcelManager.DTO.Base;
using ParcelManager.DTO.Enums;
using ParcelManager.DTO.Letters;
using ParcelManager.DTO.Parcels;

namespace ParcelManager.DTO.Bags
{
    public class BagDto : BaseDto
    {
        public string BagNumber { get; set; } = default!;
        public BagTypes BagType { get; set; }
        public LettersDto? Letters { get; set; }
        public ParcelListDto Parcels { get; set; } = default!;
    }
}