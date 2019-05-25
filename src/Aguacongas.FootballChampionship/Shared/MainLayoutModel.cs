using Aguacongas.FootballChampionship.Components;
using Aguacongas.FootballChampionship.Model;
using Aguacongas.FootballChampionship.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Layouts;
using System;
using System.Collections.Generic;
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

        protected IEnumerable<Provider> ProviderList { get; } = new List<Provider>
        {
            new Provider
            {
                Name = "Google",
                LoginText = "Login with Google",
                IconUrl = "https://pbs.twimg.com/profile_images/1057899591708753921/PSpUS-Hp_bigger.jpg"
            },
            new Provider
            {
                Name = "Facebook",
                LoginText = "Login with Facebook",
                IconUrl = "https://static.xx.fbcdn.net/rsrc.php/yo/r/iRmz9lCMBD2.ico"
            }
            ,
            new Provider
            {
                Name = "Microsoft",
                LoginText = "Login with Microsoft",
                IconUrl = "https://apps.dev.microsoft.com/favicon.ico?v=2"
            },
            new Provider
            {
                Name = "LoginWithAmazon",
                LoginText = "Login with Amazon",
                IconUrl = "https://www.amazon.com/favicon.ico"
            }
        };


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
                var response = await AwsJsInterop.GraphQlAsync<CompetitionList>(Queries.LIST_COMPETITIONS, 
                new
                {
                    Filter = new
                    {
                        From = new 
                        {
                            Ge = DateTimeOffset.Now
                        }
                    }
                });
            }
        }
    }
}
