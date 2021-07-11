using AutoMapper;
using ParcelManager.API.Interfaces;
using ParcelManager.Core.Entities;
using ParcelManager.Core.Interfaces;
using ParcelManager.DTO.Shipments;
using System.Threading.Tasks;

namespace ParcelManager.API.Services
{
    public class ShipmentDtoService : IShipmentDtoService
    {
        private readonly IShipmentRepository _shipmentRepository;

        private readonly IMapper _mapper;

        public ShipmentDtoService(IShipmentRepository shipmentRepository, IMapper mapper)
        {
            _shipmentRepository = shipmentRepository;
            _mapper = mapper;
        }

        public async Task<ShipmentDto> AddShipment(ShipmentAddDto shipmentDto)
        {
            var shipment = _mapper.Map<Shipment>(shipmentDto);
            shipment = await _shipmentRepository.AddAsync(shipment);

            return _mapper.Map<ShipmentDto>(shipment);
        }

        public async Task<ShipmentDto> FinalizeShipment(int id)
        {
            var shipment = await _shipmentRepository.GetByIdAsync(id);

            shipment.IsFinalized = true;

            await _shipmentRepository.UpdateAsync(shipment);

            return _mapper.Map<ShipmentDto>(shipment);
        }

        public async Task<ShipmentDto> GetShipment(int id)
        {
            var shipment = await _shipmentRepository.GetWithBagsAndParcelsAsync(id);

            return _mapper.Map<ShipmentDto>(shipment);
        }

        public async Task<ShipmentListDto> ListShipments()
        {
            var shipments = await _shipmentRepository.ListAsNoTrackingAsync();

            return _mapper.Map<ShipmentListDto>(shipments);
        }
    }
}
