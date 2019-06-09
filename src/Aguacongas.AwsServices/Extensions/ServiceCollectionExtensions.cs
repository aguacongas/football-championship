using Aguacongas.AwsServices;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAwsAmplify(this IServiceCollection services)
        {
            return services.AddSingleton<IAwsHelper, AwsHelper>()
                .AddSingleton<IAwsJsInterop, AwsJsInterop>();
        }
    }
}
