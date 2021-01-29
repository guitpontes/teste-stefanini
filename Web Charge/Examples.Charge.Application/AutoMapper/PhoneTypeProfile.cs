using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Charge.Application.AutoMapper
{
    public class PhoneTypeProfile : Profile
    {
        public PhoneTypeProfile()
        {
            CreateMap<PhoneNumberType, PhoneTypeDto>()
              .ReverseMap()
              .ForMember(dest => dest.PhoneNumberTypeID, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));


            CreateMap<PhoneNumberType, PhoneTypeResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PhoneNumberTypeID));
        }
    }
}
