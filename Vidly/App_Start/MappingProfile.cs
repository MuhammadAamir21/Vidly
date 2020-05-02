using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    //load this when application starts in global.asax
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Mapping convention base on propteries name
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());

            //Mapping Profile For Movie to MovieDto

            //Source to destination
            Mapper.CreateMap<Movie, MovieDto>();
            //Ignoring mapping of id becaue it is a primay key can't be change
            Mapper.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore());

            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
        }
    }
}