using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Clients.CQRS.Queries;
using Clients.Database.Repositories;
using Clients.Mapping;
using MockQueryable.NSubstitute;
using NSubstitute;
using NUnit.Framework;

namespace Clients.Test
{
	[TestFixture]
    public class GetAllClientsHandlerTest
    {
		private GetAllClientsHandler _handler;
		private IRepository<Database.Entities.Client> _repository;
		private IMapper _mapper;

		[SetUp]
		public void SetUp()
		{
			_repository = Substitute.For<IRepository<Database.Entities.Client>>();

			_mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddMaps(typeof(ClientProfile).Assembly)));

			var data = new List<Database.Entities.Client>()
			{
				new Database.Entities.Client
				{
					ClientId = 1,
					LastName = "1",
					FirstName = "1"
				},
				new Database.Entities.Client
				{
					ClientId = 1,
					LastName = "1",
					FirstName = "1"
				},
			}.AsQueryable().BuildMock();

			_repository.GetAll().Returns(data);

			_handler = new GetAllClientsHandler(_repository, _mapper);
		}

		[Test]
		public async Task GetAllClient_Count_Test()
		{
			var result = await _handler.Handle(new GetAllClientsRequest(), CancellationToken.None);

			Assert.AreEqual(2, result.Count);
		}
    }
}
