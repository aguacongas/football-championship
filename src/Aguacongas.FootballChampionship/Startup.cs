using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Aguacongas.FootballChampionship
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAwsAmplify();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
