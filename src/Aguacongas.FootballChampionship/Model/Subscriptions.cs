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
    scores {
      isHome
      value
    }
  }
}";
    }    
}
