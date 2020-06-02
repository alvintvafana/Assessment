using Assessment.Subscription.Domain.Commands;
using Assessment.Subscription.Domain.Queries;
using System.Threading.Tasks;

namespace Assessment.Subscription.Api
{
    public interface IMediator
    {
        Task DispatchAsync(ICommand command);
        Task<T> DispatchAsync<T>(IQuery<T> query);
    }
}
