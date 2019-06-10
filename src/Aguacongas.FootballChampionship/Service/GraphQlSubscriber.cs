using Aguacongas.FootballChampionship.Model;
using Aguacongas.AwsServices;
using Microsoft.JSInterop;
using System;

namespace Aguacongas.FootballChampionship.Service
{
    public class GraphQlSubscriber : IGraphQlSubscriber
    {
        public event EventHandler<Match> MatchUpdated;

        [JSInvokable]
        public void OnMatchUpdated(AwsEvent<OnUpdateMatchSubscription> evt)
        {
            MatchUpdated?.Invoke(this, evt.Value.Data.OnUpdateMatch);
        }
    }
}
