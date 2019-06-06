using System;
using Aguacongas.FootballChampionship.Model;
using Aguacongas.FootballChampionship.Services;

namespace Aguacongas.FootballChampionship.Service
{
    public interface IGraphQlSubscriber
    {
        Action<Match> MatchUpdated { get; set; }

        void OnMatchUpdated(AwsEvent<OnUpdateMatchSubscription> evt);
    }
}