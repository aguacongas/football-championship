using Aguacongas.FootballChampionship.Admin.Model.FIFA;
using Aguacongas.FootballChampionship.Model;
using Aguacongas.FootballChampionship.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;

namespace Aguacongas.FootballChampionship.Service
{
    public class LiveScoreService : ILiveScoreService
    {
        private readonly IAwsJsInterop _awsJsInterop;
        private readonly IAwsHelper _awsHelper;
        private readonly HttpClient _httpClient;
        private Timer _timer;
        public LiveScoreService(IAwsJsInterop awsJsInterop,
            IAwsHelper awsHelper,
            HttpClient httpClient)
        {
            _awsJsInterop = awsJsInterop;
            _awsHelper = awsHelper;
            _httpClient = httpClient;
        }

        public void Start(IEnumerable<Competition> competitions)
        {
            if (!_awsHelper.User.IsAdmin() || _timer != null)
            {
                return;
            }

            foreach (var competition in competitions)
            {
                competition.Matches = new AwsGraphQlList<Model.Match>
                {
                    Items = new List<Model.Match>()
                };
            }

            _timer = new Timer(async state =>
            {
                foreach (var competition in competitions)
                {
                    var response = await _httpClient.GetJsonAsync<FifaResponse<Admin.Model.FIFA.Match>>("https://api.fifa.com/api/v1/live/football/recent/" + competition.Id);
                    var fifaMatches = response.Results.Where(m => m.MatchStatus == 3);
                    var matches = competition.Matches.Items;
                    foreach (var fifaMatch in fifaMatches)
                    {
                        var match = matches.FirstOrDefault(m => m.Id == fifaMatch.IdMatch);
                        if (match == null)
                        {
                            match = new Model.Match
                            {
                                Id = fifaMatch.IdMatch,
                                Scores = new List<Score>
                                {
                                    new Score{ IsHome = true, Value = fifaMatch.HomeTeam.Score},
                                    new Score{ IsHome = false, Value = fifaMatch.AwayTeam.Score}
                                }
                            };
                            ((List<Model.Match>)matches).Add(match);
                        }
                        else
                        {
                            var homeScore = match.Scores.First(s => s.IsHome);
                            var awayScore = match.Scores.First(s => !s.IsHome);
                            if (homeScore.Value == fifaMatch.HomeTeam.Score && awayScore.Value == fifaMatch.AwayTeam.Score)
                            {
                                continue;
                            }
                            homeScore.Value = fifaMatch.HomeTeam.Score;
                            awayScore.Value = fifaMatch.AwayTeam.Score;
                        }
                        Console.WriteLine($"Update score {Json.Serialize(match)}");
                        await _awsJsInterop.GraphQlAsync<MatchesResponse>(Admin.Model.Mutations.UPDATE_MATCH,
                        new
                        {
                            input = new
                            {
                                id = match.Id,
                                scores = match.Scores
                            }
                        });
                    }
                }
            }, null, 0, 5000);
        }
    }
}
