using Microsoft.AspNetCore.Mvc;
using ParcelManager.API.Interfaces;
using ParcelManager.DTO.Parcels;
using ParcelManager.DTO.Base;
using ParcelManager.DTO.Enums;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ParcelManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParcelController : ControllerBase
    {
        private readonly IParcelDtoService _parcelDtoService;

        public ParcelController(IParcelDtoService parcelDtoService)
        {
            _parcelDtoService = parcelDtoService;
        }

        [HttpPost]
        public async Task<Response<ParcelDto>> Post([FromBody] ParcelAddDto parcelDto)
        {
            return new Response<ParcelDto>
            {
                Status = ResponseStatuses.Success,
                Message = "Successfully added parcel!",
                Data = await _parcelDtoService.AddParcel(parcelDto)
            };
        }
    }
}
