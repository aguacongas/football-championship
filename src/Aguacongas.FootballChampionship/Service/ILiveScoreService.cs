using System.Collections.Generic;
using Aguacongas.FootballChampionship.Model;

namespace Aguacongas.FootballChampionship.Service
{
    public interface ILiveScoreService
    {
        void Start(IEnumerable<Competition> competitions);
    }
}