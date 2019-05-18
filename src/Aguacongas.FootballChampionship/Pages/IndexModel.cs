using Aguacongas.FootballChampionship.Components;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace Aguacongas.FootballChampionship.Pages
{
    public class IndexModel : ComponentBase
    {
        protected IEnumerable<Provider> ProviderList { get; } = new List<Provider>
        {
            new Provider
            {
                Name = "Google",
                LoginText = "Login with Google"
            },
            new Provider
            {
                Name = "Facebook",
                LoginText = "Login with Facebook"
            }
        };
    }
}
