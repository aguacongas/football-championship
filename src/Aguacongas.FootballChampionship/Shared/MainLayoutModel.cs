using Aguacongas.FootballChampionship.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Layouts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aguacongas.FootballChampionship.Shared
{
    public class MainLayoutModel: LayoutComponentBase
    {
        private IAwsHelper _awsHelper;
        [Inject]
        public IAwsHelper AwsHelper
        {
            get { return _awsHelper; }
            set
            {
                _awsHelper = value;
                _awsHelper.UserChanged += (e, a) =>
                {
                    StateHasChanged();
                };
            }
        }

        [Inject]
        public IComponentContext ComponentContext { get; set; }

        [Inject]
        public IAwsJsInterop AwsJsInterop { get; set; }

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
    }
}
