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

            modelBuilder.Entity<Shipment>(entity =>
            {
                entity.HasAlternateKey(s => s.ShipmentNumber);
                entity.Property(s => s.ShipmentNumber).IsRequired().HasMaxLength(10).IsFixedLength();
                entity.Property(s => s.FlightNumber).HasMaxLength(6).IsFixedLength();
            });

            modelBuilder.Entity<Bag>(entity =>
            {
                entity.HasAlternateKey(b => b.BagNumber);
                entity.Property(b => b.BagNumber).IsRequired().HasMaxLength(15);
            });

            modelBuilder.Entity<BagWithLetters>(entity =>
            {
                entity.Property(b => b.LetterCount).IsRequired();
                entity.Property(b => b.Weight).HasColumnType("decimal(10, 3)");
                entity.Property(b => b.Price).HasColumnType("decimal(10, 2)");
            });
            
            modelBuilder.Entity<Parcel>(entity =>
            {
                entity.HasAlternateKey(p => p.ParcelNumber);
                entity.Property(b => b.ParcelNumber).IsRequired().HasMaxLength(10).IsFixedLength();
                entity.Property(b => b.RecipientName).HasMaxLength(100);
                entity.Property(b => b.DestinationCountry).HasMaxLength(2).IsFixedLength();
                entity.Property(b => b.Weight).HasColumnType("decimal(10, 3)");
                entity.Property(b => b.Price).HasColumnType("decimal(10, 2)");
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
