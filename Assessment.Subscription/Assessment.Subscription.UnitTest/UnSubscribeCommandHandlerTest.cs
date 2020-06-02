using Assessment.Subscription.Domain;
using Assessment.Subscription.Domain.CommandHandlers;
using Assessment.Subscription.Domain.Commands;
using Assessment.Subscription.UnitTest.Mocks;
using Moq;
using System;
using Xunit;

namespace Assessment.Subscription.UnitTest
{
    public class UnSubscribeCommandHandlerTest
    {
        private readonly IRepository<Domain.Entities.Subscription> _repositoryMock;

        public UnSubscribeCommandHandlerTest()
        {
            _repositoryMock = new MockBookRepository<Domain.Entities.Subscription>();

        }
        [Fact]
        public async void UnSubscribeBook()
        {
            var mockDb = _repositoryMock as MockBookRepository<Domain.Entities.Subscription>;
            var subsciption = new Domain.Entities.Subscription(Guid.NewGuid(),Guid.NewGuid(),"Author" );
            mockDb.Table.Add(subsciption.SubsciptionId, subsciption);

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(a => a.SaveAsync());
            var commandHandler = new UnSubscribeCommandHandler(_repositoryMock, mockUnitOfWork.Object);


            var command = new UnSubscribeCommand
            {
                SubcriptionId= subsciption.SubsciptionId
            };

            await commandHandler.HandleAsync(command);

            var dbCheck = _repositoryMock as MockBookRepository<Domain.Entities.Subscription>;

            var row = dbCheck.Table[subsciption.SubsciptionId];

            Assert.False(row.IsSubscribed);
           
        }
    }
}
