using System;
using System.Threading.Tasks;
using Aguacongas.FootballChampionship.Model;
using Aguacongas.FootballChampionship.Model.Admin;

namespace Aguacongas.FootballChampionship.Admin.Service
{
    public interface IImportService
    {
        Task ImportCompetitionFromFIFA(ImportCompetition importCompetition);
        Action<Competition> CompetitionUpdated { get; set; }

        Action<Match> MatchUpdated { get; set; }
    }
}