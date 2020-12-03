using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
		public async Task<Unit> Handle(DeleteClientRequest request, CancellationToken cancellationToken)
		{
			return Unit.Value;
		}
	}

}
