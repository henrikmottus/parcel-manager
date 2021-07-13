using AutoMapper;
using FluentValidation;
using ParcelManager.API.Interfaces;
using ParcelManager.Core.Entities;
using ParcelManager.Core.Interfaces;
using ParcelManager.DTO.Shipments;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelManager.API.Services
{
    public class ShipmentDtoService : IShipmentDtoService
    {
        private readonly IShipmentRepository _shipmentRepository;

        private readonly IValidator<Shipment> _shipmentValidator;
        private readonly IMapper _mapper;

        public ShipmentDtoService(
            IShipmentRepository shipmentRepository,
            IMapper mapper,
            IValidator<Shipment> shipmentValidator)
        {
            _shipmentRepository = shipmentRepository;
            _shipmentValidator = shipmentValidator;
            _mapper = mapper;
        }

        public async Task<ShipmentDto> AddShipment(ShipmentAddDto shipmentDto)
        {
            var shipment = _mapper.Map<Shipment>(shipmentDto);
            _shipmentValidator.ValidateAndThrow(shipment);
            shipment = await _shipmentRepository.AddAsync(shipment);

            return _mapper.Map<ShipmentDto>(shipment);
        }

        public async Task<ShipmentDto> FinalizeShipment(int id)
        {
            var shipment = await _shipmentRepository.GetWithBagsAndParcelsAsync(id);

            shipment.IsFinalized = true;

            _shipmentValidator.ValidateAndThrow(shipment);

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
