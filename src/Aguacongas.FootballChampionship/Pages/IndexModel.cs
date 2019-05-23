using Aguacongas.FootballChampionship.Components;
using Aguacongas.FootballChampionship.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aguacongas.FootballChampionship.Pages
{
    public class IndexModel : ComponentBase
    {
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

        [Inject]
        public AwsJsInterop AwsJsInterop { get; set; }


        protected override async Task OnAfterRenderAsync()
        {
            await base.OnAfterRenderAsync();
        }
    }
}
