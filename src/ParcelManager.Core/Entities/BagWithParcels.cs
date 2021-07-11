using System.Collections.Generic;

namespace ParcelManager.Core.Entities
{
    public class BagWithParcels : Bag
    {
        ICollection<Parcel> Parcels { get; set; } = default!;
    }
}
