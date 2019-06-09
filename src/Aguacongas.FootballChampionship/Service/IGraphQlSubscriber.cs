using System;
using Aguacongas.FootballChampionship.Model;
using Aguacongas.AwsServices;

namespace Aguacongas.FootballChampionship.Service
{
    public interface IGraphQlSubscriber
    {
        Action<Match> MatchUpdated { get; set; }

        void OnMatchUpdated(AwsEvent<OnUpdateMatchSubscription> evt);
    }
}