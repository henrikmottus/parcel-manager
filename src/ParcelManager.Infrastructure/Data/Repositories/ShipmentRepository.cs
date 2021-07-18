using Microsoft.EntityFrameworkCore;
using ParcelManager.Core.Entities;
using ParcelManager.Core.Interfaces;
using ParcelManager.Infrastructure.Data.Context;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelManager.Infrastructure.Data.Repositories
{
    public class ShipmentRepository : AsyncRepository<Shipment>, IShipmentRepository
    {

        public ShipmentRepository(ParcelContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<Shipment> GetWithBagsAndParcelsAsync(int id, bool asNoTracking)
        {
            var query = _dbContext.Set<Shipment>()
                .Include(s => s.Bags)
                    .ThenInclude(b => (b as BagWithParcels)!.Parcels)
                .AsQueryable();

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            return await query
                .FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
