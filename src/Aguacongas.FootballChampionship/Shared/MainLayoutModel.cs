using Aguacongas.FootballChampionship.Interop;
using Aguacongas.FootballChampionship.Localization;
using Aguacongas.FootballChampionship.Model;
using Aguacongas.FootballChampionship.Service;
using Aguacongas.FootballChampionship.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [Inject]
        public IResources Resources { get; set; }

        [Inject]
        public IBrowserJsInterop BrowserJsInterop { get; set; }

        [Inject]
        public IGraphQlSubscriber GraphQlSubscriber { private get; set; }

        protected IEnumerable<Provider> ProviderList { get; private set; }

        protected override async Task OnInitAsync()
        {
            await base.OnInitAsync();
            
            var culture = await BrowserJsInterop.GetItem<string>("culture");
            if (culture == null)
            {
                culture = await BrowserJsInterop.GetLanguage();
            }
            if (!Queries.CULTURE_LIST.Any(c => culture == c))
            {
                culture = "en-GB";
            }

            Resources.SetCulture(culture);
            CreateProviderList();

            Resources.CultureChanged += (e, a) =>
            {
                CreateProviderList();
                StateHasChanged();
            };
        }

        private void CreateProviderList()
        {
            ProviderList = new List<Provider>
            {
                new Provider
                {
                    Name = "Google",
                    LoginText = "Google",
                    IconUrl = "https://pbs.twimg.com/profile_images/1057899591708753921/PSpUS-Hp_bigger.jpg"
                },
                new Provider
                {
                    Name = "Facebook",
                    LoginText = "Facebook",
                    IconUrl = "https://img.icons8.com/color/52/000000/facebook.png"
                }
                ,
                new Provider
                {
                    Name = "Microsoft",
                    LoginText = "Microsoft",
                    IconUrl = "https://img.icons8.com/color/96/000000/windows-logo.png"
                },
                new Provider
                {
                    Name = "LoginWithAmazon",
                    LoginText = "Amazon",
                    IconUrl = "https://www.amazon.com/favicon.ico"
                }
            };
        }

        protected override async Task OnAfterRenderAsync()
        {
            if (ComponentContext.IsConnected)
            {
                await AwsJsInterop.ConfigureAsync();
                await AwsJsInterop.ListenAsync();
                if (AwsHelper.IsConnected)
                {
                    await AwsJsInterop.GraphSubscribeAsync(Subscriptions.ON_UPDATE_MATCH, GraphQlSubscriber, nameof(GraphQlSubscriber.OnMatchUpdated));
                }
            }
            await base.OnAfterRenderAsync();
        }
    }
}
