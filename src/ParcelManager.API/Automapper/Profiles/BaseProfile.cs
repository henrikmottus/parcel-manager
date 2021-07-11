using AutoMapper;
using ParcelManager.Core.Entities;
using ParcelManager.DTO.Bags;
using ParcelManager.DTO.Letters;
using ParcelManager.DTO.Parcels;
using ParcelManager.DTO.Shipments;
using System.Collections.Generic;

namespace ParcelManager.API.Automapper.Profiles
{
    public class BaseProfile : Profile
    {
        public BaseProfile()
        {
            CreateMap<ShipmentAddDto, Shipment>();
            CreateMap<Shipment, ShipmentDto>();
            CreateMap<IEnumerable<Shipment>, ShipmentListDto>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));
            CreateMap<BagAddDto, Bag>()
                .Include<BagAddDto, BagWithParcels>()
                .Include<BagAddDto, BagWithLetters>();
            CreateMap<BagAddDto, BagWithParcels>();
            CreateMap<BagAddDto, BagWithLetters>()
                .ForMember(dest => dest.LetterCount, opt => opt.MapFrom(src => src.Letters!.LetterCount))
                .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Letters!.Weight))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Letters!.Price));
            //CreateMap<Bag, BagDto>();
            CreateMap<BagWithLetters, LettersDto>()
                .ForMember(dest => dest.LetterCount, opt => opt.MapFrom(src => src.LetterCount))
                .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Weight))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));
            CreateMap<BagWithLetters, BagDto>();
            CreateMap<IEnumerable<Bag>, BagListDto>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));
            CreateMap<ParcelAddDto, Parcel>();
            CreateMap<Parcel, ParcelDto>();
            CreateMap<IEnumerable<Parcel>, ParcelListDto>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));
        }
    }
}
