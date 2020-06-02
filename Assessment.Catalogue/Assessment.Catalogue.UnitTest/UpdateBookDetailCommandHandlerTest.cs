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
    public class UpdateBookDetailCommandHandlerTest
    {
        private readonly IRepository<Book> _repositoryMock;

        public UpdateBookDetailCommandHandlerTest()
        {
            _repositoryMock = new MockBookRepository<Book>();

        }
        [Fact]
        public async void UpdateBookDetail_Success()
        {         
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(a => a.SaveAsync());
            var mockDb= _repositoryMock as MockBookRepository<Book>;
            var book = new Book("test1", "author 1", 100);
            mockDb.Table.Add(book.Id, book);

            var updateBookDetailCommandHandler = new UpdateBookDetailCommandHandler(_repositoryMock, mockUnitOfWork.Object);
            var updateBookDetail = new UpdateBookDetailCommand
            {
                Id=book.Id,
                Name = "test2",
                Text = "Test Author",
            };

            await updateBookDetailCommandHandler.HandleAsync(updateBookDetail);

            var row = mockDb.Table[book.Id];

            Assert.Equal(updateBookDetail.Name, row.Name);
            Assert.Equal(updateBookDetail.Text, row.Text);
        }

        [Theory]
        [InlineData("", "author 1")]
        [InlineData("test1", "")]
        public async void UpdateBookDetail_Fail(string name,string text)
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(a => a.SaveAsync());
            var mockDb = _repositoryMock as MockBookRepository<Book>;
            var book = new Book("test1", "author 1", 100);
            mockDb.Table.Add(book.Id, book);

            var updateBookDetailCommandHandler = new UpdateBookDetailCommandHandler(_repositoryMock, mockUnitOfWork.Object);
            var updateBookDetail = new UpdateBookDetailCommand
            {
                Id = book.Id,
                Name = name,
                Text = text,
            };

            await Assert.ThrowsAsync<ValidateException>(() => updateBookDetailCommandHandler.HandleAsync(updateBookDetail));
        }
    }
}
