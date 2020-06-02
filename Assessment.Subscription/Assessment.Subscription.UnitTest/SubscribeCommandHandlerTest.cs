using Assessment.Subscription.Domain;
using Assessment.Subscription.Domain.CommandHandlers;
using Assessment.Subscription.Domain.Commands;
using Assessment.Subscription.Domain.Exceptions;
using Assessment.Subscription.UnitTest.Mocks;
using Moq;
using System;
using Xunit;

namespace Assessment.Subscription.UnitTest
{
    public class SubscribeCommandHandlerTest
    {
        private readonly IRepository<Domain.Entities.Subscription> _repositoryMock;
        public SubscribeCommandHandlerTest()
        {
            _repositoryMock = new MockBookRepository<Domain.Entities.Subscription>();

        }
        [Fact]
        public async void SubscribeBook_Success()
        {         
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(a => a.SaveAsync());
            var commandHandler = new SubscribeCommandHandler(_repositoryMock, mockUnitOfWork.Object);
            var command = new SubscribeCommand
            {
                BookId = Guid.NewGuid(),
                BookName = "Test 1",
                UserId = Guid.NewGuid()
            };

            await commandHandler.HandleAsync(command);

            var dbCheck = _repositoryMock as MockBookRepository<Domain.Entities.Subscription>;

            Assert.Single(dbCheck.Table);
            Assert.Contains(dbCheck.Table.Values, a => a.UserId==command.UserId && a.BookId ==command.BookId && a.BookName==command.BookName);
        }

        [Theory]
        [InlineData("00000000-0000-0000-0000-000000000000", "author 1", "11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        [InlineData("12c43ee8-b9d3-6e51-b73f-bd9dda66e29c", "", "11c43ee8-b9d3-4e51-b73f-bd9dda66e29c")]
        [InlineData("23c43ee8-b9y3-5e51-b73f-bd9dda66e29c", "author", "00000000-0000-0000-0000-000000000000")]
        public async void SubscribeBook_Fail(Guid bookId, string bookName, Guid userId)
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(a => a.SaveAsync());
            var addBookCommandHandler = new SubscribeCommandHandler(_repositoryMock, mockUnitOfWork.Object);
            var addBookCommand = new SubscribeCommand
            {
                BookId = bookId,
                BookName = bookName,
                UserId = userId
            };

            await Assert.ThrowsAsync<ValidateException>(() => addBookCommandHandler.HandleAsync(addBookCommand));
        }
    }
}
