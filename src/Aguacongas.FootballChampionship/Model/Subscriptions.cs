namespace Aguacongas.FootballChampionship.Model
{
    public static class Subscriptions
    {
        public const string ON_UPDATE_MATCH = @"subscription OnUpdateMatch {
  onUpdateMatch {
    id
    competition {
      id
    }
    matchTeams {
      items {
        isHome
        team {
          localizedNames {
            locale,
            value
          }
        }
      }
    }
    scores {
      isHome
      value
    }
  }
}";
    }    
}
