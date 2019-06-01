using System.ComponentModel.DataAnnotations;

namespace Aguacongas.FootballChampionship.Model.Admin
{
    public class ImportCompetition
    {
        [Required]
        public int CompetitionId { get; set; }

        [Required]
        public int SeasonId { get; set; }

        public int? StageId { get; set; }
    }
}
