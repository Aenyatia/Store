using AutoMapper;
using Store.Core;
using Store.Web.Dtos;

namespace Store.Web.Mappers
{
	public static class AutoMapperMapping
	{
		public static IMapper Register()
			=> new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<Customer, CustomerDto>();
				cfg.CreateMap<Movie, MovieDto>();
				cfg.CreateMap<MembershipType, MembershipTypeDto>();
			}).CreateMapper();
	}
}
