using Assessment.Catalogue.Domain.Entities;
using Assessment.Catalogue.Domain.Queries;
using System.Threading.Tasks;

namespace Assessment.Catalogue.Domain.QueryHandlers
{
    public class GetBookQueryHandler : IQueryHandler<GetBookQuery,Book>
    {
        private readonly IRepository<Book> _repository;
        public GetBookQueryHandler(IRepository<Book> repository)
        {
            _repository = repository;
        }
        public async Task<Book> HandleAsync(GetBookQuery query)
        {
            return await _repository.GetByIDAsync(query.BookId);
        }
    }
}
