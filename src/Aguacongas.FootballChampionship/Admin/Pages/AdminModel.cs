using Aguacongas.FootballChampionship.Admin.Service;
using Aguacongas.FootballChampionship.Localization;
using Aguacongas.FootballChampionship.Model;
using Aguacongas.FootballChampionship.Model.Admin;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aguacongas.FootballChampionship.Admin.Pages
{
    public class AdminModel : ComponentBase
    {
        [Inject]
        public IImportService ImportService { get; set; }

        [Inject]
        public IResources Resources { get; set; }

        protected ImportCompetition ImportCompetition { get; private set; }

        protected List<Match> MatchList { get; private set; }

        protected bool Pending { get; set; }

        public AdminModel()
        {
            ImportCompetition = new ImportCompetition();
            MatchList = new List<Match>();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            ImportService.MatchUpdated = match =>
            {
                var existing = MatchList.FirstOrDefault(m => m.Id == match.Id);

                if (existing == null)
                {
                    MatchList.Add(match);
                }
                else
                {
                    existing.Group = match.Group;
                    existing.LocalizedNames = match.LocalizedNames;
                    existing.MatchTeams = match.MatchTeams;
                    existing.Number = match.Number;
                    existing.PlaceHolderAway = match.PlaceHolderAway;
                    existing.PlaceHolderHome = match.PlaceHolderHome;
                }
                
                StateHasChanged();
            };

            Resources.CultureChanged += (e, a) =>
            {
                StateHasChanged();
            };
        }

        protected async Task HandleValidSubmit()
        {
            Pending = true;
            await ImportService.ImportCompetitionFromFIFA(ImportCompetition);
            Pending = false;
        }

    }
}
