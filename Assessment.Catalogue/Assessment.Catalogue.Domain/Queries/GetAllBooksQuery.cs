using Assessment.Catalogue.Domain.Entities;
using System.Collections.Generic;

namespace Assessment.Catalogue.Domain.Queries
{
    public class GetAllBooksQuery: IQuery<IEnumerable<Book>>
    {
    }
}
