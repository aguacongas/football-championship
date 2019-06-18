using Aguacongas.FootballChampionship.Interop;
using Aguacongas.FootballChampionship.Localization;
using Aguacongas.FootballChampionship.Model;
using Aguacongas.FootballChampionship.Service;
using Aguacongas.AwsServices;
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

        [Inject]
        public IUriHelper UriHelper { get; set; }

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

            var location = UriHelper.GetAbsoluteUri();
            Console.WriteLine(location);
            if (location.Contains("/?p="))
            {
                UriHelper.NavigateTo(location.Replace("/?p=", ""));
            }
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
                var config = new AwsConfig
                {
                    Aws_cognito_identity_pool_id = "eu-west-2:5ad8c79a-2cdc-4da4-a94c-1c42becdf301",
                    Aws_cognito_region = "eu-west-2",
                    Aws_user_pools_id = "eu-west-2_MUFO3Qdac",
                    Aws_user_pools_web_client_id = "1ou6jkhe2u8j7sj14rek4a6mcq",
                    Oauth = new AwsOAuth
                    {
                        Domain = "football-championship-dev.auth.eu-west-2.amazoncognito.com",
                        Scope = new string[]
                        {
                            "phone",
                            "email",
                            "openid",
                            "profile",
                            "aws.cognito.signin.user.admin"
                        },
                        RedirectSignIn = UriHelper.GetBaseUri(),
                        RedirectSignOut = UriHelper.GetBaseUri(),
                        ResponseType = "code"
                    },
                    FederationTarget = "COGNITO_USER_POOLS",
                    Aws_appsync_graphqlEndpoint = "https://pod5c66d6ze73b62evt7xqpn4q.appsync-api.eu-west-2.amazonaws.com/graphql",
                    Aws_appsync_region = "eu-west-2",
                    Aws_appsync_authenticationType = "AMAZON_COGNITO_USER_POOLS"
                };
                await AwsJsInterop.ConfigureAsync(config);
                await AwsJsInterop.ListenAsync();
                if (AwsHelper.IsConnected)
                {
                    await BrowserJsInterop.NotificationOptIn();
                    var matches = new List<Match>();
                    GraphQlSubscriber.MatchUpdated += async (e, match) =>
                    {
                        if (match.MatchTeams?.Items == null ||
                            match.Scores == null)
                        {
                            return;
                        }

                        var homeTeam = match.MatchTeams.Items.First(t => t.IsHome).Team;
                        var awayTeam = match.MatchTeams.Items.First(t => !t.IsHome).Team;
                        var homeScore = match.Scores.First(s => s.IsHome).Value;
                        var awayScore = match.Scores.First(s => !s.IsHome).Value;

                        if (!matches.Any(m => m.Id == match.Id))
                        {
                            matches.Add(match);
                            return;
                        }

                        var started = matches.First(m => m.Id == match.Id);

                        var message = $"{homeTeam.LocalizedNames.GetLocalizedValue()} - {awayTeam.LocalizedNames.GetLocalizedValue()}\n{homeScore} - {awayScore}";

                        if (match.IsFinished != started.IsFinished)
                        {
                            started.IsFinished = match.IsFinished;
                            await BrowserJsInterop.Notify(Resources["Finished"], message);
                            return;
                        }

                        foreach (var score in match.Scores)
                        {
                            if (started.Scores.Any(s => s.IsHome == score.IsHome && s.Value != score.Value))
                            {
                                started.Scores = match.Scores;
                                await BrowserJsInterop.Notify("Gooooal!", message);
                                return;
                            }
                        }
                    };
                    await AwsJsInterop.GraphSubscribeAsync(Subscriptions.ON_UPDATE_MATCH, GraphQlSubscriber, nameof(GraphQlSubscriber.OnMatchUpdated));
                }
            }
            await base.OnAfterRenderAsync();
        }
    }
}
