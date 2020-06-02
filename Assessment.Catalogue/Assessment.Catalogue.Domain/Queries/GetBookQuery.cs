using Assessment.Catalogue.Domain.Entities;
using System;

namespace Assessment.Catalogue.Domain.Queries
{
    public class GetBookQuery : IQuery<Book>
    {
        public GetBookQuery(Guid bookId)
        {
            BookId = bookId;
        }
        public Guid BookId { get; private set; }
    }
}
