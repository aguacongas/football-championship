using Aguacongas.FootballChampionship.Localization;
using Aguacongas.FootballChampionship.Service;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Aguacongas.FootballChampionship
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAwsAmplify()
                .AddAdminServices()
                .AddBrowserJsInterop()
                .AddSingleton<IResources, Resources>()
                .AddSingleton<IGraphQlSubscriber, GraphQlSubscriber>()
                .AddTransient<ICompetitionService, CompetitionService>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {            
            app.AddComponent<App>("app");
        }
    }
}
