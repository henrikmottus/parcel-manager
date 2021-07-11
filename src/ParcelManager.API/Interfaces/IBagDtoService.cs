using ParcelManager.DTO.Bags;
using System.Threading.Tasks;

namespace ParcelManager.API.Interfaces
{
    public interface IBagDtoService
    {
        Task<BagDto> AddBag(BagAddDto bagDto);
    }
}
