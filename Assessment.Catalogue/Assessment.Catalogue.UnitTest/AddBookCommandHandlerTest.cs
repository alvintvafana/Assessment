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
    public class AddBookCommandHandlerTest
    {
        private readonly IRepository<Book> _repositoryMock;
        public AddBookCommandHandlerTest()
        {
            _repositoryMock = new MockBookRepository<Book>();

        }
        [Fact]
        public async void AddBookSuccess()
        {         
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(a => a.SaveAsync());
            var addBookCommandHandler = new AddBookCommandHandler(_repositoryMock, mockUnitOfWork.Object);
            var addBookCommand = new AddBookCommand
            {
                Name = "test1",
                Text = "Test Author",
                PurchasePrice = 5
            };

            await addBookCommandHandler.HandleAsync(addBookCommand);

            var dbCheck = _repositoryMock as MockBookRepository<Book>;

            Assert.Single(dbCheck.Table);
            Assert.Contains(dbCheck.Table.Values, a => a.Name == addBookCommand.Name && a.Text == addBookCommand.Text && a.PurchasePrice == addBookCommand.PurchasePrice);
        }

        [Fact]
        public async void AddBookFailForNegativePurchasePrice()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(a => a.SaveAsync());
            var addBookCommandHandler = new AddBookCommandHandler(_repositoryMock, mockUnitOfWork.Object);
            var addBookCommand = new AddBookCommand
            {
                Name = "test1",
                Text = "Test Author",
                PurchasePrice = -5
            };

            await Assert.ThrowsAsync<ValidateException>(() => addBookCommandHandler.HandleAsync(addBookCommand));
        }
    }
}
