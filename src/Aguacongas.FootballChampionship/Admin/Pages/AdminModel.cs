using Aguacongas.FootballChampionship.Admin.Service;
using Aguacongas.FootballChampionship.Model;
using Aguacongas.FootballChampionship.Model.Admin;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aguacongas.FootballChampionship.Admin.Pages
{
    public class AdminModel : ComponentBase
    {
        [Inject]
        public IImportService ImportService { get; set; }

        protected ImportCompetition ImportCompetition { get; private set; }

        protected List<Match> MatchList { get; private set; }

        public AdminModel()
        {
            ImportCompetition = new ImportCompetition();
            MatchList = new List<Match>();
        }

        protected override void OnInit()
        {
            ImportService.MatchUpdated = m =>
            {
                MatchList.Add(m);
                StateHasChanged();
            };
            base.OnInit();
        }

        protected async Task HandleValidSubmit()
        {
            await ImportService.ImportCompetitionFromFIFA(ImportCompetition);
        }

    }
}
