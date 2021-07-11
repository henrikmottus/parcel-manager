using ParcelManager.DTO.Parcels;
using System.Threading.Tasks;

namespace ParcelManager.API.Interfaces
{
    public interface IParcelDtoService
    {
        Task<ParcelDto> AddParcel(ParcelDto parcelDto);
    }
}
