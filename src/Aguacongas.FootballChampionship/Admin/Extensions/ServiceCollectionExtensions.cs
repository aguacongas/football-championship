using Aguacongas.FootballChampionship.Admin.Service;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAdminServices(this IServiceCollection services)
        {
            return services.AddTransient<IImportService, ImportService>();
        }
    }
}
