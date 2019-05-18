using Aguacongas.FootballChampionship.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Layouts;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aguacongas.FootballChampionship.Shared
{
    public class MainLayoutModel: LayoutComponentBase
    {
        [Inject]
        public IComponentContext ComponentContext { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Inject]
        public AwsJsInterop AwsJsInterop { get; set; }

        protected override async Task OnAfterRenderAsync()
        {
            if (ComponentContext.IsConnected)
            {
                await AwsJsInterop.ConfigureAsync();
                await AwsJsInterop.ListenAsync();
            }
            await base.OnAfterRenderAsync();
        }
    }
}
