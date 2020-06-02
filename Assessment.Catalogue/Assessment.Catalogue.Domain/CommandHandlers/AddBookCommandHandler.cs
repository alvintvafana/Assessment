using Assessment.Catalogue.Domain.Commands;
using Assessment.Catalogue.Domain.Entities;
using Assessment.Catalogue.Domain.Exceptions;
using System.Threading.Tasks;

namespace Assessment.Catalogue.Domain.CommandHandlers
{
    public class AddBookCommandHandler : ICommandHandler<AddBookCommand>
    {
        private readonly IRepository<Book> _repository;
        private readonly IUnitOfWork _uow;
        public AddBookCommandHandler(IRepository<Book> repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }
        public async Task HandleAsync(AddBookCommand command)
        {
            var book = await _repository.GetOneAsync(a => a.Name == command.Name && a.Text == command.Text);
            if (book != null)
                throw new ValidateException("book already exists");
            book = new Book(command.Name, command.Text, command.PurchasePrice);
            await _repository.InsertAsync(book);
            await _uow.SaveAsync();

            
        }
    }
}
