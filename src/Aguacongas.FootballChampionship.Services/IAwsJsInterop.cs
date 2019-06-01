using System.Threading.Tasks;

namespace Aguacongas.FootballChampionship.Services
{
    public interface IAwsJsInterop
    {
        Task ConfigureAsync();
        Task<TResponse> GraphQlAsync<TResponse>(string operation, object parameters = null);
        Task GraphSubscribeAsync<THelper>(string operation, THelper helper, string callback);
        Task ListenAsync();
        Task SignInAsync(string provider = null);
        Task SignOutAsync();
    }
}