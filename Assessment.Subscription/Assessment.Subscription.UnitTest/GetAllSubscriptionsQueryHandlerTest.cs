using Assessment.Subscription.Domain;
using Assessment.Subscription.Domain.Queries;
using Assessment.Subscription.Domain.QueryHandlers;
using Assessment.Subscription.UnitTest.Mocks;
using System;
using System.Linq;
using Xunit;

namespace Assessment.Subscription.UnitTest
{
    public class GetAllSubscriptionsQueryHandlerTest
    {
        private readonly IRepository<Domain.Entities.Subscription> _repositoryMock;

        public GetAllSubscriptionsQueryHandlerTest()
        {
            _repositoryMock = new MockBookRepository<Domain.Entities.Subscription>();
        }
        [Fact]
        public async void UpdateBookDetail_Success()
        {
            var mockDb = _repositoryMock as MockBookRepository<Domain.Entities.Subscription>;
            mockDb.Table.Add(Guid.NewGuid(), new Domain.Entities.Subscription(Guid.NewGuid(), Guid.NewGuid(), "Book 1"));
            mockDb.Table.Add(Guid.NewGuid(), new Domain.Entities.Subscription(Guid.NewGuid(), Guid.NewGuid(), "Book 2"));
            var query = new GetAllSubscriptionsQuery();
            var booksQuery = new GetAllSubscriptionsQueryHandler(_repositoryMock);

            var result = await booksQuery.HandleAsync(query);

            Assert.Equal(2, result.ToList().Count);
        }
    }
}
