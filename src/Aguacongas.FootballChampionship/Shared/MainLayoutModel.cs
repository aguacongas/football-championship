using Aguacongas.FootballChampionship.Components;
using Aguacongas.FootballChampionship.Services;
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
                _awsHelper.UserChanged += async (s, e) =>
                {
                    await UserChanged(s, e);
                };
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

        private async Task UserChanged(object sender, EventArgs e)
        {
            StateHasChanged();
            if (AwsHelper.UserName != null)
            {
                await AwsJsInterop.GraphQlAsync<object>(@"query ListCompetitions(
    $filter: ModelCompetitionFilterInput
    $limit: Int
    $nextToken: String
) {
    listCompetitions(filter: $filter, limit: $limit, nextToken: $nextToken) {
    items {
        id
        title
        from
        to
    }   
    nextToken
    }
}
", 
                new {
                    Filter = new
                    {
                        From = new
                        {
                            Ge = "2020- 01-01"
                        }
                    },
                    Limit = 10    
                });
            }
        }
    }
}
