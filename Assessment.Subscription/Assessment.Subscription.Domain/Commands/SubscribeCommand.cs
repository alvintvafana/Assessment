using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Subscription.Domain.Commands
{
    public class SubscribeCommand : ICommand
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public string BookName { get; set; }
    }
}
