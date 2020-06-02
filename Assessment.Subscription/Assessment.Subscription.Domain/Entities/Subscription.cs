using Assessment.Subscription.Domain.Exceptions;
using System;

namespace Assessment.Subscription.Domain.Entities
{
    public class Subscription 
    {
        public Guid SubsciptionId { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime UpdatedOn { get; private set; }
        public bool IsSubscribed { get; private set; }

        private Guid userId;
        public Guid UserId
        {
            get { return userId; }
            private set
            {
                if(value == Guid.Empty)
                     throw new ValidateException("please provide user Id");
                userId = value;
            }
        }

        private Guid bookId;
        public Guid BookId
        {
            get { return bookId; }
            private set
            {
                if (value == Guid.Empty)
                    throw new ValidateException("please provide book Id");
                bookId = value;
            }
        }
        private string bookName;
        public string BookName
        {
            get { return bookName; }
            private set
            {
                if (value == null || value == string.Empty)
                    throw new ValidateException("Name cannot be null");
                bookName = value;
            }
        }

        public Subscription( Guid userId, Guid bookId,string bookName)
        {
            SubsciptionId = Guid.NewGuid();
            UserId = userId;
            BookId = bookId;
            IsSubscribed = true;
            BookName = bookName;
            CreatedOn = DateTime.Now;
        }
        public void UnSubscribe()
        {
            IsSubscribed = false;
            UpdatedOn = DateTime.Now;
        }
    }
}
