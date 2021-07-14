using ParcelManager.DTO.Base;

namespace ParcelManager.DTO.Parcels
{
    public class ParcelDto : BaseDto
    {
        public string ParcelNumber { get; set; } = default!;
        public string RecipientName { get; set; } = default!;
        public string DestinationCountry { get; set; } = default!;
        public decimal Weight { get; set; } = default!;
        public decimal Price { get; set; } = default!;
    }
}
