using Assessment.Catalogue.Domain.Commands;
using Assessment.Catalogue.Domain.Queries;
using System.Threading.Tasks;

namespace Assessment.Catalogue.Api
{
    public interface IMediator
    {
        Task DispatchAsync(ICommand command);
        Task<T> DispatchAsync<T>(IQuery<T> query);
    }
}
