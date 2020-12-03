using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clients.CQRS.Commands;
using Clients.CQRS.Queries;
using Clients.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Clients.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;
		private readonly ILogger<ClientController> _logger;

		public ClientController(IMediator mediator, ILogger<ClientController> logger)
		{
			_mediator = mediator;
			_logger = logger;
		}

		[HttpGet]
        public async Task<ActionResult<List<ClientDto>>> GetAll()
        {
            try
            {
				var result = await _mediator.Send(new GetAllClientsRequest());

				return Ok(result);
            }
			catch (ArgumentException ex)
			{
				_logger.LogError(ex, "Bad Request Getting all clients");
				return StatusCode(StatusCodes.Status400BadRequest);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error Getting ALl Clients");
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}

		[HttpGet("{clientId:int}")]
		public async Task<ActionResult> GetById(int clientId)
		{
			try
			{
				var result = await _mediator.Send(new GetAllClientsRequest());

				return Ok(result);
			}
			catch (ArgumentException ex)
			{
				_logger.LogError(ex, "Bad Request Getting all clients");
				return StatusCode(StatusCodes.Status400BadRequest);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error Getting ALl Clients");
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}

		[HttpPut]
        public async Task<ActionResult<bool>> Update([FromBody] ClientDto client)
        {
			try
			{
				var result = await _mediator.Send(new UpdateClientRequest(client));

				return Ok(true);
			}
			catch (ArgumentException ex)
			{
				_logger.LogError(ex, "Bad Request");
				return StatusCode(StatusCodes.Status400BadRequest);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error");
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}

        [HttpPost]
        public async Task<ActionResult<int>> Add([FromBody] ClientDto client)
        {
			try
			{
				var result = await _mediator.Send(new AddClientRequest(client));

				return Ok(result);
			}
			catch (ArgumentException ex)
			{
				_logger.LogError(ex, "Bad Request");
				return StatusCode(StatusCodes.Status400BadRequest);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error");
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}

        [HttpDelete("{clientId:int}")]
        public async Task<ActionResult<bool>> Delete(int clientId)
        {
			try
			{
				var result = await _mediator.Send(new DeleteClientRequest(clientId));

				return Ok(true);
			}
			catch (ArgumentException ex)
			{
				_logger.LogError(ex, "Bad Request");
				return StatusCode(StatusCodes.Status400BadRequest);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error");
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}
    }
}
