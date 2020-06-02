using Assessment.Catalogue.Domain;
using Assessment.Catalogue.Domain.CommandHandlers;
using Assessment.Catalogue.Domain.Commands;
using Assessment.Catalogue.Domain.Entities;
using Assessment.Catalogue.Domain.Exceptions;
using Assessment.Catalogue.UnitTest.Mocks;
using Moq;
using Xunit;

namespace Assessment.Catalogue.UnitTest
{
    public class AdjustBookPriceCommandHandlerTest
    {
        private readonly IRepository<Book> _repositoryMock;

        public AdjustBookPriceCommandHandlerTest()
        {
            _repositoryMock = new MockBookRepository<Book>();

        }
        [Fact]
        public async void AdjustBookPrice_Success()
        {         
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(a => a.SaveAsync());
            var mockDb= _repositoryMock as MockBookRepository<Book>;
            var book = new Book("test1", "author 1", 100);
            mockDb.Table.Add(book.Id, book);

            var adjustBookPriceCommandHandler = new AdjustBookPriceCommandHandler(_repositoryMock, mockUnitOfWork.Object);
            var command = new AdjustBookPriceCommand
            {
                Id = book.Id,
                PurchasePrice = 150
            };

            await adjustBookPriceCommandHandler.HandleAsync(command);

            var row = mockDb.Table[book.Id];

            Assert.Equal(command.PurchasePrice, row.PurchasePrice);
        }

        [Fact]
        public async void AdjustBookPrice_Fail()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(a => a.SaveAsync());
            var mockDb = _repositoryMock as MockBookRepository<Book>;
            var book = new Book("test1", "author 1", 100);
            mockDb.Table.Add(book.Id, book);

            var adjustBookPriceCommandHandler = new AdjustBookPriceCommandHandler(_repositoryMock, mockUnitOfWork.Object);
            var command = new AdjustBookPriceCommand
            {
                Id = book.Id,
                PurchasePrice = -1
            };

           await Assert.ThrowsAsync<ValidateException>(() => adjustBookPriceCommandHandler.HandleAsync(command));
        }
    }
}
