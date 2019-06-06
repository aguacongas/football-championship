using System;
using System.Threading.Tasks;

namespace Aguacongas.FootballChampionship.Interop
{
    public interface IBrowserDateTime
    {
        Task<DateTime> ToBrowerTime(DateTime dateTime);
    }
}