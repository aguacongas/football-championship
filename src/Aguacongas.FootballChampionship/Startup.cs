using Aguacongas.FootballChampionship.Localization;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace Aguacongas.FootballChampionship
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAwsAmplify()
                .AddAdminServices()
                .AddBrowserJsInterop()
                .AddSingleton<IResources, Resources>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {            
            app.AddComponent<App>("app");
        }
    }
}
