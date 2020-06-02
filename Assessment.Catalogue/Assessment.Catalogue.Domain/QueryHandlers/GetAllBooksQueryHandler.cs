using Assessment.Catalogue.Domain.Entities;
using Assessment.Catalogue.Domain.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assessment.Catalogue.Domain.QueryHandlers
{
    public class GetAllBooksQueryHandler : IQueryHandler<GetAllBooksQuery, IEnumerable<Book>>
    {
        private readonly IRepository<Book> _repository;
        public GetAllBooksQueryHandler(IRepository<Book> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Book>> HandleAsync(GetAllBooksQuery query)
        {
            return await _repository.GetAsync();
        }
    }
}
