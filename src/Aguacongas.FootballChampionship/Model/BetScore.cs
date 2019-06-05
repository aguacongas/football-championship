using System.ComponentModel.DataAnnotations;

namespace Aguacongas.FootballChampionship.Model
{
    public class BetScore
    {
        public string Id { get; set; }

        public string MatchId { get; set; }

        [Required]
        public int? HomeValue { get; set; }

        [Required]
        public int? AwayValue { get; set; }
    }
}
