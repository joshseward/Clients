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

namespace Clients.CQRS.Commands
{

	public class AddClientRequest : IRequest<int>
	{
		public AddClientRequest(ClientDto client)
		{
			Client = client;
		}

		public ClientDto Client { get; set; }
	}

	public class AddClientHandler : IRequestHandler<AddClientRequest, int>
	{
		private readonly IRepository<Client> _clientRepository;
		private readonly IMapper _mapper;

		public AddClientHandler(IRepository<Client> clientRepository, IMapper mapper)
		{
			_clientRepository = clientRepository;
			_mapper = mapper;
		}

		public async Task<int> Handle(AddClientRequest request, CancellationToken cancellationToken)
		{
			if(request == null)
			{
				throw new ArgumentException("Request cannot  be null");
			}

			var client = _mapper.Map<Client>(request.Client);

			await _clientRepository.Add(client);
			await _clientRepository.SaveChangesAsync();

			return client.ClientId;
		}
	}

}
