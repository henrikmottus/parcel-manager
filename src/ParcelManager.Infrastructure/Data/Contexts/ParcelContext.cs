using Microsoft.EntityFrameworkCore;
using ParcelManager.Core.Entities;
using System;

namespace ParcelManager.Infrastructure.Data.Context
{
    public partial class ParcelContext : DbContext
    {

        public ParcelContext(DbContextOptions<ParcelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Parcel> Parcels { get; set; } = default!;
        public virtual DbSet<BagWithParcels> BagsWithParcels { get; set; } = default!;
        public virtual DbSet<BagWithLetters> BagsWithLetters { get; set; } = default!;
        public virtual DbSet<Shipment> Shipments { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.Entity<Shipment>().HasAlternateKey(s => s.ShipmentNumber);

            modelBuilder.Entity<Bag>().HasAlternateKey(b => b.BagNumber);
            
            modelBuilder.Entity<Parcel>().HasAlternateKey(p => p.ParcelNumber);

            base.OnModelCreating(modelBuilder);
        }

    }
}
