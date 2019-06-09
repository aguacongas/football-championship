using Aguacongas.AwsServices;

namespace Aguacongas.FootballChampionship.Model
{
    public class BetResponses
    {
        public AwsGraphQlList<Bet> ListBets { get; set; }

        public Bet UpdateBet { get; set; }

        public Bet CreateBet { get; set; }
    }
}
