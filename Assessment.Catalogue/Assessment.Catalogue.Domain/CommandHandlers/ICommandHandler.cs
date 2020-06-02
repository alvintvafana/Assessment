using Assessment.Catalogue.Domain.Commands;
using System.Threading.Tasks;

namespace Assessment.Catalogue.Domain.CommandHandlers
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        Task HandleAsync(TCommand command);
    }
}
