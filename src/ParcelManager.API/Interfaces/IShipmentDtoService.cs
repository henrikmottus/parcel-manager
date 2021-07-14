using ParcelManager.DTO.Shipments;
using System.Threading.Tasks;

namespace ParcelManager.API.Interfaces
{
    public interface IShipmentDtoService
    {
        Task<ShipmentListDto> ListShipments();
        Task<ShipmentDto> GetShipment(int id);
        Task<ShipmentDto> AddShipment(ShipmentAddDto shipmentDto);
        Task<ShipmentDto> FinalizeShipment(int id);
        Task<ShipmentDto> EditShipment(int id, ShipmentEditDto shipmentDto);
    }
}
