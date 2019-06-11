using System;
using Aguacongas.FootballChampionship.Model;
using Aguacongas.AwsServices;
using System.Threading.Tasks;

namespace Aguacongas.FootballChampionship.Service
{
    public interface IGraphQlSubscriber
    {
        event EventHandler<Match> MatchUpdated;

        Task OnMatchUpdated(AwsEvent<OnUpdateMatchSubscription> evt);
    }
}