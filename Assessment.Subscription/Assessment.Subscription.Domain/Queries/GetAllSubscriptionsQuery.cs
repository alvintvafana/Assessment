using Assessment.Subscription.Domain.Entities;
using System.Collections.Generic;

namespace Assessment.Subscription.Domain.Queries
{
    public class GetAllSubscriptionsQuery: IQuery<IEnumerable<Entities.Subscription>>
    {
    }
}
