using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Clients.Database.Entities;
using Clients.Database.Repositories;
using Clients.Dtos;
using MediatR;

namespace Clients.CQRS.Queries
{
	public class GetClientByIdRequest : IRequest<ClientDto>
	{
		public GetClientByIdRequest(int clientId)
		{
			ClientId = clientId;
		}

		public int ClientId { get; set; }
	}

	public class GetClientByIdHandler : IRequestHandler<GetClientByIdRequest, ClientDto>
	{
		private readonly IRepository<Client> _clientRepository;
		private readonly IMapper _mapper;

		public GetClientByIdHandler(IRepository<Client> clientRepository, IMapper mapper)
		{
			_clientRepository = clientRepository;
			_mapper = mapper;
		}

		public async Task<ClientDto> Handle(GetClientByIdRequest request, CancellationToken cancellationToken)
		{
			if (request == null) 
			{
				throw new ArgumentException("Request cannot be null");
			}

			return _mapper.Map<ClientDto>(await _clientRepository.Get(request.ClientId));
		}
	}

}
