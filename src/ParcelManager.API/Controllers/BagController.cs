using Microsoft.AspNetCore.Mvc;
using ParcelManager.API.Interfaces;
using ParcelManager.DTO.Bags;
using ParcelManager.DTO.Base;
using ParcelManager.DTO.Enums;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ParcelManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BagController : ControllerBase
    {
        private readonly IBagDtoService _bagDtoService;

        public BagController(IBagDtoService bagDtoService)
        {
            _bagDtoService = bagDtoService;
        }

        [HttpPost]
        public async Task<Response<BagDto>> Post([FromBody] BagAddDto bagDto)
        {
            return new Response<BagDto>
            {
                Status = ResponseStatuses.Success,
                Message = "Successfully added bag!",
                Data = await _bagDtoService.AddBag(bagDto)
            };
        }
    }
}
