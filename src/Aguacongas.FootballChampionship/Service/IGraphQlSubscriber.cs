using System;
using Aguacongas.FootballChampionship.Model;
using Aguacongas.AwsServices;

namespace Aguacongas.FootballChampionship.Service
{
    public interface IGraphQlSubscriber
    {
        event EventHandler<Match> MatchUpdated;

        void OnMatchUpdated(AwsEvent<OnUpdateMatchSubscription> evt);
    }
}