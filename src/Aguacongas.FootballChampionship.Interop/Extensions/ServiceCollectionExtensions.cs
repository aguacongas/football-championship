
using Aguacongas.FootballChampionship.Interop;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBrowserJsInterop(this IServiceCollection services)
        {
            return services.AddSingleton<IBrowserJsInterop, BrowserJsInterop>();
        }
    }
}
