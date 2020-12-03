using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Clients.Database.Entities;
using Clients.Database.Repositories;
using MediatR;

namespace Clients.CQRS.Commands
{
	public class DeleteClientRequest : IRequest
	{
		public DeleteClientRequest(int clientId)
		{
			ClientId = clientId;
		}

		public int ClientId { get; set; }
	}

	public class DeleteClientHandler : IRequestHandler<DeleteClientRequest>
	{
		private readonly IRepository<Client> _clientRepository;

		public DeleteClientHandler(IRepository<Client> clientRepository)
		{
			_clientRepository = clientRepository;
		}

		public async Task<Unit> Handle(DeleteClientRequest request, CancellationToken cancellationToken)
		{
			if (request == null)
			{
				throw new ArgumentException("Request cannot  be null");
			}

			var client = await _clientRepository.Get(request.ClientId);

			if(client != null)
			{
				_clientRepository.Delete(client);
				await _clientRepository.SaveChangesAsync();
			}			
			return Unit.Value;
		}
	}

}
