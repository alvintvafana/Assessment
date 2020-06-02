using Assessment.Catalogue.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Catalogue.Domain.QueryHandlers
{
    public interface IQueryHandler<TQuery, TResult>
    {
       Task<TResult> HandleAsync(TQuery query);
    }
}
