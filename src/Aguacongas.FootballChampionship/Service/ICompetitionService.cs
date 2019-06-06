using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aguacongas.FootballChampionship.Model;

namespace Aguacongas.FootballChampionship.Service
{
    public interface ICompetitionService
    {
        Competition Competition { get; }
        IEnumerable<Match> Matches { get; }
        IEnumerable<IGrouping<DateTime, Match>> MatchGroup { get; }

        Task Initialize(string competitionId);
        Task SaveBet(BetScore bet);
    }
}