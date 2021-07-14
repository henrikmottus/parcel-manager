using AutoMapper;
using FluentValidation;
using ParcelManager.API.Interfaces;
using ParcelManager.Core.Entities;
using ParcelManager.Core.Interfaces;
using ParcelManager.DTO.Bags;
using ParcelManager.DTO.Enums;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelManager.API.Services
{
    public class BagDtoService : IBagDtoService
    {
        private readonly IAsyncRepository<Bag> _bagRepository;
        private readonly IValidator<BagWithLetters> _bagWithLettersValidator;
        private readonly IValidator<BagWithParcels> _bagWithParcelsValidator;

        private readonly IMapper _mapper;

        public BagDtoService(
            IAsyncRepository<Bag> bagRepository,
            IValidator<BagWithLetters> bagWithLettersValidator,
            IValidator<BagWithParcels> bagWithParcelsValidator,
            IMapper mapper)
        {
            _bagRepository = bagRepository;
            _bagWithLettersValidator = bagWithLettersValidator;
            _bagWithParcelsValidator = bagWithParcelsValidator;
            _mapper = mapper;
        }

        public async Task<BagDto> AddBag(BagAddDto bagDto)
        {
            Bag bag;
            if (bagDto.BagType == BagTypes.Letters)
            {
                bag = _mapper.Map<BagWithLetters>(bagDto);
                _bagWithLettersValidator.ValidateAndThrow((BagWithLetters)bag);
            }
            else
            {
                bag = _mapper.Map<BagWithParcels>(bagDto);
                _bagWithParcelsValidator.ValidateAndThrow((BagWithParcels)bag);
            }

            var bags = await _bagRepository.ListAsNoTrackingAsync();
            if (bags.Any(s => s.BagNumber == bag.BagNumber))
            {
                throw new ApplicationException("Bag number must be unique!");
            }

            bag = await _bagRepository.AddAsync(bag);

            return _mapper.Map<BagDto>(bag);
        }
    }
}
