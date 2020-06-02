using Assessment.Subscription.Api.Dtos;
using Assessment.Subscription.Api.helpers;
using Assessment.Subscription.Domain.Commands;
using Assessment.Subscription.Domain.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Assessment.Subscription.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubscriptionController : ControllerBase
    {
        private readonly ILogger<SubscriptionController> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpClientService _client;
        private readonly IOptions<Settings> _options;
        public SubscriptionController(ILogger<SubscriptionController> logger, IMediator mediator, IHttpClientService client, IOptions<Settings> options)
        {
            _logger = logger;
            _mediator = mediator;
            _client = client;
            _options = options;
        }

        [HttpPost("SubscribeCommand")]
        public async Task<IActionResult> SubscribeCommand([FromBody] SubscribeDto value, [FromHeader] Guid userId)
        {
            _logger.LogInformation("Subscribe for user:{0}, bookid:{1} ", userId, value.BookId);
            var book = await _client.GetRequest(new BookDto(), $"{_options.Value.CatalogueUrl}{_options.Value.BookQueryPath}{value.BookId}");
            if (book == null)
                throw new InvalidDataException("book provided does not exist");
            var command = new SubscribeCommand
            {
                BookId = value.BookId,
                BookName = book.Name,
                UserId = userId
            };
            await _mediator.DispatchAsync(command);
            _logger.LogInformation("Subscribed for user:{0}, bookid:{1} ", userId, value.BookId);
            return Ok();
        }

        [HttpPost("UnSubscribeCommand")]
        public async Task<IActionResult> UnSubscribeCommand([FromBody] UnSubscribeDto value)
        {
            _logger.LogInformation("UnSubscribe for subriptionId:{0} ", value.SubcriptionId);
            var command = new UnSubscribeCommand { SubcriptionId = value.SubcriptionId };
            await _mediator.DispatchAsync(command);
            _logger.LogInformation("UnSubscribed for subriptionId:{0} ", value.SubcriptionId);
            return Ok();
        }

        [HttpGet("GetAllSubscriptionsQuery")]
        public async Task<IActionResult> GetAllSubscriptionsQuery()
        {
            _logger.LogInformation("Get all subscriptions");
           var result= await _mediator.DispatchAsync(new GetAllSubscriptionsQuery());
            _logger.LogInformation("Done retrieving subscriptions");
            return Ok(result);
        }
    }
}
