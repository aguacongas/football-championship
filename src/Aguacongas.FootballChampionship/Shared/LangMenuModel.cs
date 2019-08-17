using Aguacongas.FootballChampionship.Interop;
using Aguacongas.FootballChampionship.Localization;
using Aguacongas.FootballChampionship.Model;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Aguacongas.FootballChampionship.Shared
{
    public class LangMenuModel : ComponentBase
    {
        [Inject]
        public IResources Resources { private get; set; }

        [Inject]
        public IBrowserJsInterop BrowserJsInterop { private get; set; }

        [Inject]
        public IUriHelper UriHelper { protected get; set; }

        protected string Language { get; private set; }

        protected IEnumerable<string> LanguageList { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            LanguageList = Queries.CULTURE_LIST.Select(c => c.Split('-')[0]);

            var culture = CultureInfo.DefaultThreadCurrentUICulture.ToString();
            Language = culture.Split('-')[0];

            UriHelper.OnLocationChanged += (e, a) =>
            {
                StateHasChanged();
            };
        }

        protected async Task SetLanguage(string language)
        {
            var culture = Queries.CULTURE_LIST.First(c => c.StartsWith(language));
            Language = language;
            await BrowserJsInterop.SetItem("culture", culture);
            Resources.SetCulture(culture);
        }
    }
}
