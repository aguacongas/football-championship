using Aguacongas.FootballChampionship.Model;
using Aguacongas.FootballChampionship.Service;
using Aguacongas.FootballChampionship.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aguacongas.FootballChampionship.Pages
{
    public class CompetitionModel : LocalizedComponentBase
    {
        [Parameter]
        public string Id { get; set; }

        [Parameter]
        public string Stage { get; set; }

        [Inject]
        public ICompetitionService CompetitionService { private get; set; }

        [Inject]
        public IGraphQlSubscriber GraphQlSubscriber { private get; set; }


        protected Model.Competition Competition { get; private set; }

        protected IEnumerable<IGrouping<DateTime, Match>> MatchGroup { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            
            GraphQlSubscriber.MatchUpdated += (e, match) =>
            {
                var cm = CompetitionService.Matches.FirstOrDefault(m => m.Id == match.Id);
                if (cm != null)
                {
                    cm.Scores = match.Scores;
                    cm.IsFinished = match.IsFinished;
                    StateHasChanged();
                }
            };

            await CompetitionService.Initialize($"{Id}/{Stage}");

            Competition = CompetitionService.Competition;
            MatchGroup = CompetitionService.MatchGroup;
        }

        protected string GetTeamName(Match match, bool isHome)
        {
            var matchTeam = match.MatchTeams.Items.FirstOrDefault(m => m.IsHome == isHome);
            if (matchTeam != null)
            {
                return matchTeam.Team.LocalizedNames.GetLocalizedValue();
            }

            if (isHome)
            {
                return match.PlaceHolderHome;
            }

            return match.PlaceHolderAway;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            await CompetitionService.ScrollToDate();
        }

        protected string GetTeamUrl(Match match, bool isHome)
        {
            var matchTeam = match.MatchTeams.Items.FirstOrDefault(m => m.IsHome == isHome);
            if (matchTeam != null)
            {
                return matchTeam.Team.FlagUrl.Replace("{format}-{size}", "wwc2019-4");
            }
            return null;
        }

        protected string GetErrorMessage(Match match, bool isHome)
        {
            return string.Format(Resources["The score for {0} is required."], GetTeamName(match, isHome));
        }
        protected async Task SaveBet(BetScore bet)
        {
            await CompetitionService.SaveBet(bet);
            StateHasChanged();
        }

        protected bool CanBet(Match match)
        {
            return DateTime.Now < match.BeginAt &&
                (match.Scores == null || !match.Scores.Any());
        }        
    }
}
