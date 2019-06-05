﻿using Aguacongas.FootballChampionship.Localization;
using Aguacongas.FootballChampionship.Model;
using Aguacongas.FootballChampionship.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aguacongas.FootballChampionship.Pages
{
    public class IndexModel : ComponentBase
    {
        [Inject]
        public IAwsJsInterop AwsJsInterop { get; set; }

        [Inject]
        public IResources Resources { get; set; }

        protected IEnumerable<Model.Competition> CompetitionList { get; private set; }

        protected override  async Task OnInitAsync()
        {
            var response = await AwsJsInterop.GraphQlAsync<CompetitionList>(Queries.LIST_COMPETITIONS,
                new
                {
                    Filter = new
                    {
                        From = new
                        {
                            Ge = DateTimeOffset.Now
                        }
                    }
                });
            CompetitionList = response.ListCompetitions.Items;

            Resources.CultureChanged += (e, a) =>
            {
                StateHasChanged();
            };
        }
    }
}
