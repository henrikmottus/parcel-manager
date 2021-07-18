using ParcelManager.Core.Entities;
using System.Threading.Tasks;

namespace ParcelManager.Core.Interfaces
{
    public interface IShipmentRepository : IAsyncRepository<Shipment>
    {
        Task<Shipment> GetWithBagsAndParcelsAsync(int id, bool asNoTracking);
    }
}