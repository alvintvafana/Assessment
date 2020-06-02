using Assessment.Catalogue.Domain.Commands;
using Assessment.Catalogue.Domain.Entities;
using Assessment.Catalogue.Domain.Exceptions;
using System.Threading.Tasks;

namespace Assessment.Catalogue.Domain.CommandHandlers
{
    public class AdjustBookPriceCommandHandler : ICommandHandler<AdjustBookPriceCommand>
    {
        private readonly IRepository<Book> _repository;
        private readonly IUnitOfWork _uow;
        public AdjustBookPriceCommandHandler(IRepository<Book> repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }
        public async Task HandleAsync (AdjustBookPriceCommand command)
        {

            var book = await _repository.GetByIDAsync(command.Id);
            if(book==null)
                throw new ValidateException("book doesnot exists");
            book.AdjustPurchasePrice(command.PurchasePrice);
            _repository.Update(book);
            await _uow.SaveAsync();
        }
    }
}
