using Assessment.Subscription.Domain.Entities;
using Assessment.Subscription.Domain.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assessment.Subscription.Domain.QueryHandlers
{
    public class GetAllSubscriptionsQueryHandler : IQueryHandler<GetAllSubscriptionsQuery, IEnumerable<Entities.Subscription>>
    {
        private readonly IRepository<Entities.Subscription> _repository;
        public GetAllSubscriptionsQueryHandler(IRepository<Entities.Subscription> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Entities.Subscription>> HandleAsync(GetAllSubscriptionsQuery query)
        {
            return await _repository.GetAsync();
        }
    }
}
