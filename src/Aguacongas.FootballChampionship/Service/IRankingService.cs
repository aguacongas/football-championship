using System.Collections.Generic;
using System.Threading.Tasks;
using Aguacongas.FootballChampionship.Model;

namespace Aguacongas.FootballChampionship.Service
{
    public interface IRankingService
    {
        Competition Competition { get; }
        Task<IEnumerable<Result>> ComputeResultList(string competitionId);
    }
}