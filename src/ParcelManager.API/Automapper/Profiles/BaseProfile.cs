using AutoMapper;
using ParcelManager.Core.Entities;
using ParcelManager.DTO.Bags;
using ParcelManager.DTO.Enums;
using ParcelManager.DTO.Parcels;
using ParcelManager.DTO.Shipments;
using System.Collections.Generic;
using System.Linq;

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
                .ForMember(dest => dest.LetterCount, opt => opt.MapFrom(src => src.Letters!.Count))
                .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Letters!.Weight))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Letters!.Price));

            CreateMap<Bag, BagDto>()
                .Include<BagWithParcels, BagDto>()
                .Include<BagWithLetters, BagDto>();
            CreateMap<BagWithParcels, BagDto>()
                .ForMember(dest => dest.BagType, opt => opt.MapFrom(src => BagTypes.Parcels));
            // The next map is not needed by itself, but reverse mapping is the easiest way to unflatten an object
            CreateMap<BagDto, BagWithLetters>()
                .ForMember(dest => dest.LetterCount, opt => opt.MapFrom(src => src.Letters!.Count))
                .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Letters!.Weight))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Letters!.Price))
                .ReverseMap();
            CreateMap<IEnumerable<Bag>, BagListDto>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));

            CreateMap<ParcelAddDto, Parcel>();

            CreateMap<Parcel, ParcelDto>();
            CreateMap<IEnumerable<Parcel>, ParcelListDto>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Count()))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Sum(b => b.Price)));
        }
    }
}
