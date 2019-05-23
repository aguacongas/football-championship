﻿using Aguacongas.FootballChampionship.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAwsAmplify(this IServiceCollection services)
        {
            return services.AddSingleton<AwsHelper>()
                .AddSingleton<AwsJsInterop>();
        }
    }
}