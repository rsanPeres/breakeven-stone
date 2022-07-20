using AutoFixture;
using BreakevenStoneApplication.CommandHandlers;
using BreakevenStoneDomain.Commands;
using BreakevenStoneDomain.Entities;
using BreakevenStoneRepository.Repositories;
using Moq;
using System.Threading;
using Xunit;

namespace BreakevenStoneApplication.UnitTest.CommandHandlers
{
    public class UserCommandHandlerTests
    {
        private CreateUserCommandHandler _createHandler;
        private Fixture _fixture;
        private Mock<ClientRepository> _repository;

        public UserCommandHandlerTests()
        {
            _fixture = new Fixture();
            _createHandler = _fixture.Create<CreateUserCommandHandler>();
            _repository = new Mock<ClientRepository>();
        }

        [Fact]
        public async void CreateEmployeeCommandHandler_GivenAnCommand_ShouldSaveDataBase()
        {
            var command = _fixture.Create<CreateUserCommand>();

            await _createHandler.Handle(command, CancellationToken.None);
            _repository.Verify(x => x.Create(It.IsAny<User>()), Times.Once);

        }
    }
}
