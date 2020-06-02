using System;
using System.Threading.Tasks;

namespace Assessment.Subscription.Domain
{
    public interface IUnitOfWork : IDisposable 
    {
        Task SaveAsync();
    }
}
