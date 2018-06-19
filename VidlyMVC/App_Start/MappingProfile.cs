using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyMVC.DTOS;
using VidlyMVC.Models;

namespace VidlyMVC.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile() //Old code, this is obsolete, but works fine.
        {
            Mapper.Initialize(config =>
            {
                Mapper.CreateMap<Customer, CustomerDto>();
                Mapper.CreateMap<CustomerDto, Customer>();
                Mapper.CreateMap<Movie, MovieDto>();

                // DTO to Domain:
                Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
                Mapper.CreateMap<MovieDto, Movie>().ForMember(c => c.Id, opt => opt.Ignore());
            });
        }
    }
}