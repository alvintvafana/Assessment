using Assessment.Subscription.Domain.Commands;
using Assessment.Subscription.Domain.Exceptions;
using System.Threading.Tasks;

namespace Assessment.Subscription.Domain.CommandHandlers
{
    public class SubscribeCommandHandler : ICommandHandler<SubscribeCommand>
    {
        private readonly IRepository<Entities.Subscription> _repository;
        private readonly IUnitOfWork _uow;
        public SubscribeCommandHandler(IRepository<Entities.Subscription> repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }
        public async Task HandleAsync(SubscribeCommand command)
        {
            var subscription = await _repository.GetOneAsync(a => a.UserId == command.UserId && a.BookId == command.BookId);
            if (subscription != null)
                throw new ValidateException("You are already subscribed");
            subscription = new Entities.Subscription(command.UserId,command.BookId,command.BookName);
            await _repository.InsertAsync(subscription);
            await _uow.SaveAsync();

            
        }
    }
}
