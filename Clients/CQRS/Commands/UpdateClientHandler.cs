using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
		public async Task<Unit> Handle(UpdateClientRequest request, CancellationToken cancellationToken)
		{
			return Unit.Value;
		}
	}

}
