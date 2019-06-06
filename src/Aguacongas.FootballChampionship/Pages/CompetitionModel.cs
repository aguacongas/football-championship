﻿using Aguacongas.FootballChampionship.Localization;
using Aguacongas.FootballChampionship.Model;
using Aguacongas.FootballChampionship.Service;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aguacongas.FootballChampionship.Pages
{
    public class CompetitionModel : ComponentBase
    {
        [Parameter]
        protected string Id { get; set; }

        [Parameter]
        protected string Stage { get; set; }

        [Inject]
        public ICompetitionService CompetitionService { private get; set; }

        [Inject]
        public IResources Resources { get; set; }

        [Inject]
        public IGraphQlSubscriber GraphQlSubscriber { private get; set; }


        protected Model.Competition Competition { get; private set; }

        protected IEnumerable<IGrouping<DateTime, Match>> MatchGroup { get; private set; }

        protected override async Task OnInitAsync()
        {
            await base.OnInitAsync();
            
            GraphQlSubscriber.MatchUpdated = match =>
            {
                var cm = CompetitionService.Matches.FirstOrDefault(m => m.Id == match.Id);
                if (cm != null)
                {
                    cm.Scores = match.Scores;
                    StateHasChanged();
                }
            };
            
            Resources.CultureChanged += (e, a) =>
            {
                StateHasChanged();
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
