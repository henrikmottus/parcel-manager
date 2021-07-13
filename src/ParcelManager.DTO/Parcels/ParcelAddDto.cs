namespace ParcelManager.DTO.Parcels
{
    public class ParcelAddDto
    {
        public int BagId { get; set; }
        public string ParcelNumber { get; set; } = default!;
        public string RecipientName { get; set; } = default!;
        public string DestinationCountry { get; set; } = default!;
        public float Weight { get; set; } = default!;
        public float Price { get; set; } = default!;
    }
}
