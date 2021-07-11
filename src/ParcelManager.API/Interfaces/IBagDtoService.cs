using ParcelManager.DTO.Bags;
using System.Threading.Tasks;

namespace ParcelManager.API.Interfaces
{
    public interface IBagDtoService
    {
        Task<BagListDto> ListBagsForShipment(int shipmentId);
        Task<BagDto> AddBag(BagDto bagDto);
    }
}
