using AutoMapper;
using BookAPI.Dtos;
using BookAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BookAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Country, CountryDto>();
            CreateMap<CountryDto, Country>();
        }
    }
}
