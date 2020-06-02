using System;

namespace Assessment.Subscription.Domain.Exceptions
{
    public class ValidateException: Exception
    {
        public ValidateException(string message) : base(message)
        {

        }
    }
}
