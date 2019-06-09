using Aguacongas.FootballChampionship.Model;
using Aguacongas.AwsServices;
using Microsoft.JSInterop;
using System;

namespace Aguacongas.FootballChampionship.Service
{
    public class GraphQlSubscriber : IGraphQlSubscriber
    {
        public Action<Match> MatchUpdated { get; set; }

        [JSInvokable]
        public void OnMatchUpdated(AwsEvent<OnUpdateMatchSubscription> evt)
        {
            MatchUpdated?.Invoke(evt.Value.Data.OnUpdateMatch);
        }
    }
}
