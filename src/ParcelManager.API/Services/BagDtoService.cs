using AutoMapper;
using ParcelManager.API.Interfaces;
using ParcelManager.Core.Entities;
using ParcelManager.Core.Interfaces;
using ParcelManager.DTO.Bags;
using ParcelManager.DTO.Enums;
using System.Threading.Tasks;

namespace ParcelManager.API.Services
{
    public class BagDtoService : IBagDtoService
    {
        private readonly IAsyncRepository<Bag> _bagRepository;

        private readonly IMapper _mapper;

        public BagDtoService(IAsyncRepository<Bag> bagRepository, IMapper mapper)
        {
            _bagRepository = bagRepository;
            _mapper = mapper;
        }

        public async Task<BagDto> AddBag(BagAddDto bagDto)
        {
            Bag bag = bagDto.BagType == BagTypes.Letters
                ? _mapper.Map<BagWithLetters>(bagDto)
                : _mapper.Map<BagWithParcels>(bagDto);

            bag = await _bagRepository.AddAsync(bag);

            return _mapper.Map<BagDto>(bag);
        }
    }
}
