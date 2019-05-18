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
        private AwsHelper _awsHelper;

        [Inject]
        public AwsHelper AwsHelper
        {
            get { return _awsHelper; }
            set
            {
                _awsHelper = value;
                _awsHelper.UserChanged += UserChanged;
            }
        }

        [Inject]
        public IComponentContext ComponentContext { get; set; }

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

        private void UserChanged(object sender, EventArgs e)
        {
            StateHasChanged();
        }
    }
}
