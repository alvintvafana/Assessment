using System.Threading.Tasks;

namespace Assessment.Subscription.Api.helpers
{
    public interface IHttpClientService
    {
         Task<T> GetRequest<T>(T contectResult, string contentUrl) where T : class;
    }
}
