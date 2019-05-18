using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

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

        [Inject]
        public AwsHelper AwsHelper { get; set; }

    }
}
