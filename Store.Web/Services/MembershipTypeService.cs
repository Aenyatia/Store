using AutoMapper;
using Store.Core;
using Store.Web.Dtos;
using System.Collections.Generic;

namespace Store.Web.Services
{
	public class MembershipTypeService
	{
		private readonly IMapper _mapper;

		private static readonly ISet<MembershipType> MembershipTypes = new HashSet<MembershipType>
		{
			new MembershipType()
		};

		public MembershipTypeService(IMapper mapper)
		{
			_mapper = mapper;
		}

		public IEnumerable<MembershipTypeDto> GetMembershipTypes()
		{
			return _mapper.Map<IEnumerable<MembershipType>, IEnumerable<MembershipTypeDto>>(MembershipTypes);
		}
	}
}
