using AutoMapper;
using ParcelManager.API.Interfaces;
using ParcelManager.Core.Entities;
using ParcelManager.Core.Interfaces;
using ParcelManager.DTO.Parcels;
using System.Threading.Tasks;

namespace ParcelManager.API.Services
{
    public class ParcelDtoService : IParcelDtoService
    {
        private readonly IAsyncRepository<Parcel> _parcelRepository;

        private readonly IMapper _mapper;

        public ParcelDtoService(IAsyncRepository<Parcel> parcelRepository, IMapper mapper)
        {
            _parcelRepository = parcelRepository;
            _mapper = mapper;
        }

        public async Task<ParcelDto> AddParcel(ParcelAddDto parcelDto)
        {
            var parcel = _mapper.Map<Parcel>(parcelDto);
            parcel = await _parcelRepository.AddAsync(parcel);

            return _mapper.Map<ParcelDto>(parcel);
        }
    }
}
