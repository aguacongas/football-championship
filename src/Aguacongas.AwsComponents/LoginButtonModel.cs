using Aguacongas.AwsServices;
using Microsoft.AspNetCore.Components;

namespace Aguacongas.AwsComponents
{
    public class LoginButtonModel : ComponentBase
    {
        [Inject]
        public IAwsJsInterop AwsJsInterop { get; set; }

        [Parameter]
        public string Text { get; set; }

        [Parameter]
        public string Provider { get; set; }

        [Parameter]
        public string IconUrl { get; set; }
    }
}
