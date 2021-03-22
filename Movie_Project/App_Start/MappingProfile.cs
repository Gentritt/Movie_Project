using AutoMapper;
using Movie_Project.DTO;
using Movie_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movie_Project.App_Start
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			Mapper.CreateMap<Customer, CustomerDto>();
			Mapper.CreateMap<CustomerDto, Customer>();
			Mapper.CreateMap<MembershipType, MembershipTypeDto>();

			Mapper.CreateMap<Movie, MovieDto>();
			Mapper.CreateMap<MovieDto, Movie>();


			Mapper.CreateMap<CustomerDto, Customer>()
			   .ForMember(c => c.Id, opt => opt.Ignore());

			Mapper.CreateMap<MovieDto, Movie>()
				.ForMember(c => c.Id, opt => opt.Ignore());
		}
	}
}