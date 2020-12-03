using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Clients.Database.Entities;
using Clients.Dtos;

namespace Clients.Mapping
{
	public class ClientProfile: Profile
	{
		public ClientProfile()
		{
			CreateMap<Client, ClientDto>()
				.ReverseMap()
				.ForMember(dest => dest.CreatedDate, opt => opt.Ignore());
		}
	}
}
