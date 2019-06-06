using System.ComponentModel.DataAnnotations;

namespace Aguacongas.FootballChampionship.Model
{
    public class BetScore
    {
        private int? homeValue;
        private int? awayValue;

        public string Id { get; set; }

        public string MatchId { get; set; }

        public bool ValueChanged { get; set; }

        public bool Saved { get; set; }

        [Required]
        public int? HomeValue
        {
            get => homeValue;
            set
            {
                homeValue = value;
                ValueChanged = true;
                Saved = false;
            }
        }

        [Required]
        public int? AwayValue
        {
            get => awayValue;
            set
            {
                awayValue = value;
                ValueChanged = true;
                Saved = false;
            }
        }
    }
}
