using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;

namespace Examples.Charge.Application.AutoMapper
{
    public class PhoneProfile : Profile
    {
        public PhoneProfile()
        {
            CreateMap<PersonPhone, PhoneDto>()
               .ReverseMap()
               .ForMember(dest => dest.BusinessEntityID, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
               .ForMember(dest => dest.PhoneNumberType, opt => opt.MapFrom(src => src.PhoneType));

            CreateMap<PersonPhone, PhoneResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BusinessEntityID))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => src.Person.Name))
                .ForMember(dest => dest.PhoneType, opt => opt.MapFrom(src => src.PhoneNumberType.Name));
        }
    }
}
