namespace ParcelManager.Core.Entities
{
    public abstract class Bag : BaseEntity
    {
        public string BagNumber { get; set; } = default!;

        public int ShipmentId { get; set; }
        public Shipment Shipment { get; set; } = default!;
    }
}
