using System.Threading.Tasks;

namespace Aguacongas.AwsServices
{
    public interface IAwsJsInterop
    {
        Task ConfigureAsync(AwsConfig config);
        Task<TResponse> GraphQlAsync<TResponse>(string operation, object parameters = null);
        Task GraphSubscribeAsync<THelper>(string operation, THelper helper, string callback) where THelper : class;
        Task ListenAsync();
        Task SignInAsync(string provider = null);
        Task SignOutAsync();
    }
}