using Assessment.Subscription.Domain.Commands;
using Assessment.Subscription.Domain.Exceptions;
using System.Threading.Tasks;

namespace Assessment.Subscription.Domain.CommandHandlers
{
    public class UnSubscribeCommandHandler : ICommandHandler<UnSubscribeCommand>
    {
        private readonly IRepository<Entities.Subscription> _repository;
        private readonly IUnitOfWork _uow;
        public UnSubscribeCommandHandler(IRepository<Entities.Subscription> repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }
        public async Task HandleAsync(UnSubscribeCommand command)
        {
            var subscription = await _repository.GetByIDAsync(command.SubcriptionId);
            if (subscription == null)
                throw new ValidateException("You are already subscribed");
            subscription.UnSubscribe();
             _repository.Update(subscription);
            await _uow.SaveAsync();

            
        }
    }
}
