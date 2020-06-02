using System;

namespace Assessment.Subscription.Domain.Commands
{
    public class UnSubscribeCommand : ICommand
    {
        public Guid SubcriptionId { get; set; }
    }
}
