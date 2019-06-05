using Aguacongas.FootballChampionship.Services;

namespace Aguacongas.FootballChampionship.Model
{
    public class BetResponses
    {
        public AwsGraphQlList<Bet> ListBets { get; set; }

        public Bet UpdateBet { get; set; }

        public Bet CreateBet { get; set; }
    }
}
