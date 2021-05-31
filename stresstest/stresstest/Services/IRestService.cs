using System.Threading.Tasks;

namespace stresstest.Services
{
    public interface IRestService
    {
       
        Task<string> GetItemAsync(string id);
    }
}