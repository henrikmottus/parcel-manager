using System.Collections.Generic;

namespace ParcelManager.Core.Entities
{
    public class BagWithParcels : Bag
    {
        public ICollection<Parcel> Parcels { get; set; } = default!;
    }
}
