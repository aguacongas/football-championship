using Aguacongas.FootballChampionship.Localization;
using Microsoft.AspNetCore.Components;

namespace Aguacongas.FootballChampionship.Shared
{
    public class LocalizedComponentBase : ComponentBase
    {
        [Inject]
        public IResources Resources { get; set; }

        protected override void OnInit()
        {
            base.OnInit();

            Resources.CultureChanged += (e, a) =>
            {
                StateHasChanged();
            };
        }

    }
}
