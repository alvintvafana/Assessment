using Assessment.Subscription.Domain.Commands;
using System.Threading.Tasks;

namespace Assessment.Subscription.Domain.CommandHandlers
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        Task HandleAsync(TCommand command);
    }
}
