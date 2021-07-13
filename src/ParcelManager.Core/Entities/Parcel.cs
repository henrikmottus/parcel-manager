namespace ParcelManager.Core.Entities
{
    public class Parcel : BaseEntity
    {
        public string ParcelNumber { get; set; } = default!;
        public string RecipientName { get; set; } = default!;
        public string DestinationCountry { get; set; } = default!;
        public float Weight { get; set; } = default!;
        public float Price { get; set; } = default!;

        public int BagId { get; set; }
        public BagWithParcels Bag { get; set; } = default!;
    }
}
