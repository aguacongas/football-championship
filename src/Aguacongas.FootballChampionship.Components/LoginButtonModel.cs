﻿using Microsoft.AspNetCore.Components;

namespace Aguacongas.FootballChampionship.Components
{
    public class LoginButtonModel : ComponentBase
    {
        [Inject]
        public AwsJsInterop AwsJsInterop { get; set; }

        [Parameter]
        public string Text { get; set; }

        [Parameter]
        public string Provider { get; set; }

        [Parameter]
        public string IconUrl { get; set; }

    }
}
