using ParcelManager.DTO.Base;

namespace ParcelManager.DTO.Parcels
{
    public class ParcelListDto : IEnumerableDto<ParcelDto>
    {
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}
