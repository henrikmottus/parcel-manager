using Microsoft.EntityFrameworkCore;
using ParcelManager.Core.Entities;
using ParcelManager.Core.Interfaces;
using ParcelManager.Infrastructure.Data.Context;
using System.Threading.Tasks;

namespace ParcelManager.Infrastructure.Data.Repositories
{
    public class ShipmentRepository : AsyncRepository<Shipment>, IShipmentRepository
    {

        public ShipmentRepository(ParcelContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<Shipment> GetWithBagsAndParcelsAsync(int id)
        {
            var bagsWithParcels = _dbContext.BagsWithParcels;
            var bagsWithLetters = _dbContext.BagsWithLetters;
            return await _dbContext.Shipments
                .AsNoTracking()
                .Include(s => s.Bags)
                .ThenInclude(b => ((BagWithParcels)b).Parcels)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
