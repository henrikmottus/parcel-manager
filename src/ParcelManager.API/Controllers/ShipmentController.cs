using Microsoft.AspNetCore.Mvc;
using ParcelManager.API.Interfaces;
using ParcelManager.DTO.Base;
using ParcelManager.DTO.Enums;
using ParcelManager.DTO.Shipments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ParcelManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentController : ControllerBase
    {
        private readonly IShipmentDtoService _shipmentDtoService;

        public ShipmentController(IShipmentDtoService shipmentDtoService)
        {
            _shipmentDtoService = shipmentDtoService;
        }

        [HttpGet]
        public async Task<Response<ShipmentListDto>> List()
        {
            return new Response<ShipmentListDto>
            {
                Status = ResponseStatuses.Success,
                Message = "Successfully retrieved shipments!",
                Data = await _shipmentDtoService.ListShipments()
            };
        }

        [HttpGet("{id}")]
        public async Task<Response<ShipmentDto>> Get(int id)
        {
            return new Response<ShipmentDto>
            {
                Status = ResponseStatuses.Success,
                Message = "Successfully retrieved shipment!",
                Data = await _shipmentDtoService.GetShipment(id)
            };
        }

        [HttpPost]
        public async Task<Response<ShipmentDto>> Post([FromBody] ShipmentAddDto shipmentDto)
        {
            return new Response<ShipmentDto>
            {
                Status = ResponseStatuses.Success,
                Message = "Successfully added shipment!",
                Data = await _shipmentDtoService.AddShipment(shipmentDto)
            };
        }

        [HttpPut("finalize/{id}")]
        public async Task<Response<ShipmentDto>> Put(int id)
        {
            return new Response<ShipmentDto>
            {
                Status = ResponseStatuses.Success,
                Message = "Successfully finalized shipment!",
                Data = await _shipmentDtoService.FinalizeShipment(id)
            };
        }
    }
}
