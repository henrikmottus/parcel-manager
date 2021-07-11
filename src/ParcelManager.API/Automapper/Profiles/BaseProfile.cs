using AutoMapper;
using ParcelManager.Core.Entities;
using ParcelManager.DTO.Bags;
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
            CreateMap<Bag, BagDto>();
            CreateMap<IEnumerable<Bag>, BagListDto>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));
            CreateMap<Parcel, ParcelDto>();
            CreateMap<IEnumerable<Parcel>, ParcelListDto>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));
        }
        //CreateMap<TechpulseProc, TechpulseDto>()
        //    .ForMember(dest => dest.AdoptionRate, opt => opt.MapFrom(src => src.DAR))
        //    .ForMember(dest => dest.UtlizationRate, opt => opt.MapFrom(src => src.DUR))
        //    .ForMember(dest => dest.SyncDate, opt => opt.MapFrom(src => src.DateT))
        //    ;
    }
}
