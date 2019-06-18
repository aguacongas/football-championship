using Aguacongas.FootballChampionship.Admin.Model.FIFA;
using Aguacongas.FootballChampionship.Model;
using Aguacongas.AwsServices;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Text.Json.Serialization;

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
                    var message = await _httpClient.GetAsync("https://api.fifa.com/api/v1/live/football/recent/" + competition.Id);
                    var content = await message.Content.ReadAsStringAsync();
                    var response = JsonSerializer.Parse<FifaResponse<Admin.Model.FIFA.Match>>(content);
                    var fifaMatches = response.Results.Where(m => m.MatchStatus == 3 || m.MatchStatus == 0);
                    var matches = competition.Matches.Items;
                    foreach (var fifaMatch in fifaMatches)
                    {
                        var match = matches.FirstOrDefault(m => m.Id == fifaMatch.IdMatch);
                        var isFinished = fifaMatch.MatchStatus == 0;
                        if (match == null)
                        {
                            match = new Model.Match
                            {
                                Id = fifaMatch.IdMatch,
                                Scores = new List<Score>
                                {
                                    new Score{ IsHome = true, Value = fifaMatch.HomeTeam.Score.Value},
                                    new Score{ IsHome = false, Value = fifaMatch.AwayTeam.Score.Value}
                                }
                            };
                            ((List<Model.Match>)matches).Add(match);                            
                        }
                        else
                        {
                            var homeScore = match.Scores.First(s => s.IsHome);
                            var awayScore = match.Scores.First(s => !s.IsHome);

                            if (homeScore.Value == fifaMatch.HomeTeam.Score && 
                                awayScore.Value == fifaMatch.AwayTeam.Score &&
                                match.IsFinished == isFinished)
                            {
                                continue;
                            }
                            homeScore.Value = fifaMatch.HomeTeam.Score.Value;
                            awayScore.Value = fifaMatch.AwayTeam.Score.Value;
                        }
                        match.IsFinished = isFinished;
                        Console.WriteLine($"Update score {JsonSerializer.ToString(match)}");
                        await _awsJsInterop.GraphQlAsync<MatchesResponse>(Admin.Model.Mutations.UPDATE_MATCH,
                        new
                        {
                            input = new
                            {
                                id = match.Id,
                                scores = match.Scores,
                                isFinished
                            }
                        });
                    }
                }
            }, null, 0, 5000);
        }
    }
}
