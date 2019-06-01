using Aguacongas.FootballChampionship.Services;
using Microsoft.AspNetCore.Components;

namespace Aguacongas.FootballChampionship.Shared
{
    public class NavMenuModel : ComponentBase
    {
        private bool collapseNavMenu = true;

        [Inject]
        public IAwsJsInterop AwsJsInterop { get; set; }

        [Inject]
        public IAwsHelper AwsHelper { get; set; }

        protected string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        protected void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }
    }
}
