namespace ParcelManager.Core.Entities
{
    public class Parcel : BaseEntity
    {
        public string ParcelNumber { get; set; } = default!;
        public string RecipientName { get; set; } = default!;
        public string DestinationCountry { get; set; } = default!;
        public decimal Weight { get; set; } = default!;
        public decimal Price { get; set; } = default!;

        public int BagId { get; set; }
        public BagWithParcels Bag { get; set; } = default!;
    }
}
