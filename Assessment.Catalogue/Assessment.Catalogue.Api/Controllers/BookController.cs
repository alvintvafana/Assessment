using Assessment.Catalogue.Domain.Commands;
using Assessment.Catalogue.Domain.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Assessment.Catalogue.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IMediator _mediator;
        public BookController(ILogger<BookController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("AddBookCommand")]
        public async Task<IActionResult> AddBookCommand([FromBody] AddBookCommand command)
        {
            _logger.LogInformation("Adding book {0}", command.Name);
            await _mediator.DispatchAsync(command);
            _logger.LogInformation("Book {0} successfully added", command.Name);
            return Ok();
        }

        [HttpPost("UpdateBookDetailCommand")]
        public async Task<IActionResult> UpdateBookDetailCommand([FromBody] UpdateBookDetailCommand command)
        {
            _logger.LogInformation("Updating book details {0}", command.Name);
            await _mediator.DispatchAsync(command);
            _logger.LogInformation("Book {0} successfully updated", command.Name);
            return Ok();
        }

        [HttpPost("AdjustBookPriceCommand")]
        public async Task<IActionResult> AdjustBookPriceCommand([FromBody] AdjustBookPriceCommand command)
        {
            _logger.LogInformation("adjusting book price id: {0}", command.Id);
            await _mediator.DispatchAsync(command);
            _logger.LogInformation("Book id:{0} successfully price adjusted", command.Id);
            return Ok();
        }

        [HttpGet("GetAllBooksQuery")]
        public async Task<IActionResult> GetAllBooksQuery()
        {
            _logger.LogInformation("Get all books");
           var result= await _mediator.DispatchAsync(new GetAllBooksQuery());
            _logger.LogInformation("Done retrieving all books");
            return Ok(result);
        }
        [HttpGet("GetBookQuery")]
        public async Task<IActionResult> GetBookQuery(Guid bookId)
        {
            _logger.LogInformation("Get book {0}",bookId);
            var result = await _mediator.DispatchAsync(new GetBookQuery(bookId));
            _logger.LogInformation("Done getting book {0}", bookId);
            return Ok(result);
        }
    }
}
