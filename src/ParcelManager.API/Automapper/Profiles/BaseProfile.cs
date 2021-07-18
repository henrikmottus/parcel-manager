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
            CreateMap<ShipmentAddDto, Shipment>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Bags, opt => opt.Ignore())
                .ForMember(dest => dest.IsFinalized, opt => opt.Ignore());
            CreateMap<Shipment, ShipmentDto>();
            CreateMap<IEnumerable<Shipment>, ShipmentListDto>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));

            CreateMap<BagAddDto, Bag>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Shipment, opt => opt.Ignore())
                .Include<BagAddDto, BagWithParcels>()
                .Include<BagAddDto, BagWithLetters>();
            CreateMap<BagAddDto, BagWithParcels>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Parcels, opt => opt.Ignore())
                .ForMember(dest => dest.Shipment, opt => opt.Ignore());
            CreateMap<BagAddDto, BagWithLetters>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Shipment, opt => opt.Ignore())
                .ForMember(dest => dest.LetterCount, opt => opt.MapFrom(src => src.Letters!.Count))
                .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Letters!.Weight))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Letters!.Price));

            CreateMap<Bag, BagDto>()
                .ForMember(dest => dest.BagType, opt => opt.Ignore())
                .ForMember(dest => dest.Letters, opt => opt.Ignore())
                .ForMember(dest => dest.Parcels, opt => opt.Ignore())
                .Include<BagWithParcels, BagDto>()
                .Include<BagWithLetters, BagDto>();
            CreateMap<BagWithParcels, BagDto>()
                .ForMember(dest => dest.Letters, opt => opt.Ignore())
                .ForMember(dest => dest.BagType, opt => opt.MapFrom(src => BagTypes.Parcels))
                .ForMember(dest => dest.Parcels, opt => opt.MapFrom(src => src.Parcels));
            // The next map is not needed by itself, but reverse mapping is the easiest way to unflatten an object
            CreateMap<BagDto, BagWithLetters>()
                .ForMember(dest => dest.Shipment, opt => opt.Ignore())
                .ForMember(dest => dest.ShipmentId, opt => opt.Ignore())
                .ForMember(dest => dest.LetterCount, opt => opt.MapFrom(src => src.Letters!.Count))
                .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Letters!.Weight))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Letters!.Price))
                .ReverseMap();
            CreateMap<IEnumerable<Bag>, BagListDto>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));

            CreateMap<ParcelAddDto, Parcel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Bag, opt => opt.Ignore());

            CreateMap<Parcel, ParcelDto>();
            CreateMap<IEnumerable<Parcel>, ParcelListDto>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Count()))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Sum(b => b.Price)));
        }
    }
}
