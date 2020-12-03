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
	public class UpdateClientRequest : IRequest
	{
		public UpdateClientRequest(ClientDto client)
		{
			Client = client;
		}

		public ClientDto Client { get; set; }
	}

	public class UpdateClientHandler : IRequestHandler<UpdateClientRequest>
	{
		private readonly IRepository<Client> _clientRepository;
		private readonly IMapper _mapper;

		public UpdateClientHandler(IRepository<Client> clientRepository, IMapper mapper)
		{
			_clientRepository = clientRepository;
			_mapper = mapper;
		}

		public async Task<Unit> Handle(UpdateClientRequest request, CancellationToken cancellationToken)
		{
			if (request == null)
			{
				throw new ArgumentException("Request cannot  be null");
			}

			var client = await _clientRepository.Get(request.Client.ClientId);

			_mapper.Map(request.Client, client);

			_clientRepository.Update(client);
			await _clientRepository.SaveChangesAsync();

			return Unit.Value;
		}
	}

}
