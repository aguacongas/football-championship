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
                .AddSingleton<ILiveScoreService, LiveScoreService>()
                .AddTransient<ICompetitionService, CompetitionService>()
                .AddTransient<IRankingService, RankingService>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {            
            app.AddComponent<App>("app");
        }
    }
}
