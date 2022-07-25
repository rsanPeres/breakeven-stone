using AutoFixture;
using BreakevenStoneApplication.CommandHandlers;
using BreakevenStoneDomain.Commands;
using BreakevenStoneDomain.Entities;
using BreakevenStoneInfra;
using BreakevenStoneRepository.Repositories;
using BreakevenStoneRepositoty.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BreakevenStoneApplication.UnitTest.CommandHandlers
{
    public class UserCommandHandlerTests
    {
        private CreateUserCommandHandler _createHandler;
        private Fixture _fixture;
        private Mock<IClientRepository> _repository;
        private Mock<DbContext> _context;

        public UserCommandHandlerTests()
        {
            _fixture = new Fixture();
            _repository = new Mock<IClientRepository>();
            _context = new Mock<DbContext>();
            var rep = new ClientRepository(_context.Object);
            _createHandler = new CreateUserCommandHandler(rep);
        }

        [Fact]
        public async Task CreateEmployeeCommandHandler_GivenAnUserCommand_ShouldSaveDataBaseAsync()
        {
            var command = _fixture.Create<CreateUserCommand>();
            _repository.Setup(x => x.Create(It.IsAny<User>())).Returns(Task.CompletedTask);
            
            var act = await _createHandler.Handle(command, CancellationToken.None);

            Assert.IsType<Response>(act);
            act.Result.Equals(new Response("Success"));
            _repository.Verify(x => x.Create(It.IsAny<User>()), Times.Once);

        }
    }
}
