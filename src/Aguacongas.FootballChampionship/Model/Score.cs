using System.ComponentModel.DataAnnotations;

namespace Aguacongas.FootballChampionship.Model
{
    public class Score
    {
        public bool IsHome { get; set; }

        [Required]
        public int Value { get; set; }
    }
}
