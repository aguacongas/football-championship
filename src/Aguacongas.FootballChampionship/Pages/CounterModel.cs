using Microsoft.AspNetCore.Components;

namespace Aguacongas.FootballChampionship.Pages
{
    public class CounterMode: ComponentBase
    {
        protected int currentCount = 0;

        protected void IncrementCount()
        {
            currentCount++;
        }
    }
}
