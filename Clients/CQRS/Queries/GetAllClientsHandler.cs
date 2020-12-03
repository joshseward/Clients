using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Clients.Database.Entities;
using Clients.Database.Repositories;
using Clients.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clients.CQRS.Queries
{

	public class GetAllClientsRequest : IRequest<List<ClientDto>>
	{

	}

	public class GetAllClientsHandler : IRequestHandler<GetAllClientsRequest, List<ClientDto>>
	{
		private readonly IRepository<Client> _clientRepository;
		private readonly IMapper _mapper;

		public GetAllClientsHandler(IRepository<Client> clientRepository, IMapper mapper)
		{
			_clientRepository = clientRepository;
			_mapper = mapper;
		}

		public async Task<List<ClientDto>> Handle(GetAllClientsRequest request, CancellationToken cancellationToken)
		{
			return await _clientRepository.GetAll()
				.ProjectTo<ClientDto>(_mapper.ConfigurationProvider)
				.ToListAsync();
		}
	}

}
