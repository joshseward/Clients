using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Clients.Database
{
	public class ClientContext: DbContext
	{
		public ClientContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Entities.Client> Client { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}
	}
}
