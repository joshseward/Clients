using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clients.Dtos
{
	public class ClientDto
	{
		public int ClientId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime CreatedDate { get; set; }
	}
}
