using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Charge.Application.AutoMapper
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonDto>()
               .ReverseMap()
               .ForMember(dest => dest.BusinessEntityID, opt => opt.MapFrom(src => src.Id));
        }
    }
}
