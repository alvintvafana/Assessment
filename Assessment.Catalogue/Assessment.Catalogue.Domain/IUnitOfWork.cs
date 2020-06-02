using System;
using System.Threading.Tasks;

namespace Assessment.Catalogue.Domain
{
    public interface IUnitOfWork : IDisposable 
    {
        Task SaveAsync();
    }
}
