﻿namespace ParcelManager.Core.Entities
{
    public abstract class Bag : BaseEntity
    {
        public string BagNumber { get; set; } = default!;
    }
}
