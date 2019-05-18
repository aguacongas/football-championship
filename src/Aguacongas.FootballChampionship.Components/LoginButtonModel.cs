using Microsoft.AspNetCore.Components;

namespace Aguacongas.FootballChampionship.Components
{
    public class LoginButtonModel : ComponentBase
    {
        [Parameter]
        public string Text { get; set; }

        [Parameter]
        public string Provider { get; set; }

        [Inject]
        public AwsJsInterop AwsJsInterop { get; set; }
    }
}
