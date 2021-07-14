using AutoMapper;
using FluentValidation;
using ParcelManager.API.Interfaces;
using ParcelManager.Core.Entities;
using ParcelManager.Core.Interfaces;
using ParcelManager.DTO.Parcels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelManager.API.Services
{
    public class ParcelDtoService : IParcelDtoService
    {
        private readonly IAsyncRepository<Parcel> _parcelRepository;
        private readonly IValidator<Parcel> _parcelValidator;

        private readonly IMapper _mapper;

        public ParcelDtoService(
            IAsyncRepository<Parcel> parcelRepository,
            IValidator<Parcel> parcelValidator,
            IMapper mapper)
        {
            _parcelRepository = parcelRepository;
            _parcelValidator = parcelValidator;
            _mapper = mapper;
        }

        public async Task<ParcelDto> AddParcel(ParcelAddDto parcelDto)
        {
            var parcel = _mapper.Map<Parcel>(parcelDto);

            _parcelValidator.ValidateAndThrow(parcel);

            var parcels = await _parcelRepository.ListAsNoTrackingAsync();
            if (parcels.Any(s => s.ParcelNumber == parcel.ParcelNumber))
            {
                throw new ApplicationException("Parcel number must be unique!");
            }

            parcel = await _parcelRepository.AddAsync(parcel);

            return _mapper.Map<ParcelDto>(parcel);
        }
    }
}
