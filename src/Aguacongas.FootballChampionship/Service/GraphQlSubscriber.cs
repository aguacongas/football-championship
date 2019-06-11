using Aguacongas.AwsServices;
using Aguacongas.FootballChampionship.Model;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Aguacongas.FootballChampionship.Service
{
    public class GraphQlSubscriber : IGraphQlSubscriber
    {
        private readonly IAwsJsInterop _awsJsInterop;
        const string GET_MATCH = @"query GetMatch($id: ID!) {
  getMatch(id: $id) {
    id
    competition {
      id
    }
    matchTeams {
      items {
        isHome
        team {
          localizedNames {
            locale
            value
          }
        }
      }
    }
    scores {
      isHome
      value
    }
    isFinished
  }
}";

        public event EventHandler<Match> MatchUpdated;

        public GraphQlSubscriber(IAwsJsInterop awsJsInterop)
        {
            _awsJsInterop = awsJsInterop;
        }

        [JSInvokable]
        public async Task OnMatchUpdated(AwsEvent<OnUpdateMatchSubscription> evt)
        {
            var matchResponses = await _awsJsInterop.GraphQlAsync<MatchesResponse>(GET_MATCH, new { id = evt.Value.Data.OnUpdateMatch.Id });
            MatchUpdated?.Invoke(this, matchResponses.GetMatch);
        }
    }
}
