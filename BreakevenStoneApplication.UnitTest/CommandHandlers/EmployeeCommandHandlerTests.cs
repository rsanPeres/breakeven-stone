using AutoFixture;
using BreakevenStoneApplication.CommandHandlers;
using BreakevenStoneDomain.Commands;
using BreakevenStoneDomain.Entities;
using BreakevenStoneRepository.Repositories;
using Moq;
using System;
using System.Threading;
using Xunit;

namespace BreakevenStoneApplication.UnitTest.CommandHandlers
{
    public class EmployeeCommandHandlerTests
    {
        private Fixture _fixture;
        private CreateEmployeeCommandHandler _createHandler;
        private Mock<EmployeeRepository> _repository;

        public EmployeeCommandHandlerTests()
        {
            _fixture = new Fixture();
            
            _repository = new Mock<EmployeeRepository>();
        }

        [Fact]
        public async void CreateEmployeeCommandHandler_GivenAnEmployeeCommand_ShouldSaveDataBase()
        {
            //var command = _fixture.Create<CreateEmployeeCommand>();
            //_createHandler = _fixture.Create<CreateEmployeeCommandHandler>();
            //await _createHandler.Handle(command, CancellationToken.None);
            //_repository.Verify(x => x.Create(It.IsAny<Employee>()), Times.Once);
            
        }

    }
}
