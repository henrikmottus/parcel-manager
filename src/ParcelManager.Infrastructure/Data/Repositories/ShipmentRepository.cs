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
            return await _dbContext.Set<Shipment>()
                .AsNoTracking()
                .Include(s => s.Bags)
                .ThenInclude(b => (b as BagWithParcels).Parcels)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
