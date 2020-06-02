using Assessment.Catalogue.Domain;
using Assessment.Catalogue.Domain.CommandHandlers;
using Assessment.Catalogue.Domain.Commands;
using Assessment.Catalogue.Domain.Entities;
using Assessment.Catalogue.Domain.Exceptions;
using Assessment.Catalogue.Domain.Queries;
using Assessment.Catalogue.Domain.QueryHandlers;
using Assessment.Catalogue.UnitTest.Mocks;
using Moq;
using System;
using System.Linq;
using System.Net.Http.Headers;
using Xunit;

namespace Assessment.Catalogue.UnitTest
{
    public class GetAllBooksQueryHandlerTest
    {
        private readonly IRepository<Book> _repositoryMock;

        public GetAllBooksQueryHandlerTest()
        {
            _repositoryMock = new MockBookRepository<Book>();
        }
        [Fact]
        public async void UpdateBookDetail_Success()
        {
            var mockDb = _repositoryMock as MockBookRepository<Book>;
            mockDb.Table.Add(Guid.NewGuid(), new Book("test1", "author 1", 100));
            mockDb.Table.Add(Guid.NewGuid(), new Book("test2", "author 2", 150));
            mockDb.Table.Add(Guid.NewGuid(), new Book("test3", "author 3", 1150));
            var query = new GetAllBooksQuery();
            var booksQuery = new GetAllBooksQueryHandler(_repositoryMock);

            var result = await booksQuery.HandleAsync(query);

            Assert.Equal(3, result.ToList().Count);
        }
    }
}
