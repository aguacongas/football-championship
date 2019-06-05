using Aguacongas.FootballChampionship.Admin.Model;
using Aguacongas.FootballChampionship.Admin.Model.FIFA;
using Aguacongas.FootballChampionship.Model;
using Aguacongas.FootballChampionship.Model.Admin;
using Aguacongas.FootballChampionship.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Aguacongas.FootballChampionship.Admin.Service
{
    public class ImportService : IImportService
    {
        private static LocalizedNameComparer _localizedNameComparer = new LocalizedNameComparer();
        private readonly HttpClient _client;
        private readonly IAwsJsInterop _awsJsInterop;

        public Action<Competition> CompetitionUpdated { get; set; }

        public Action<FootballChampionship.Model.Match> MatchUpdated { get; set; }

        public ImportService(HttpClient client, IAwsJsInterop awsJsInterop)
        {
            _client = client;
            _awsJsInterop = awsJsInterop;
        }

        public async Task ImportCompetitionFromFIFA(ImportCompetition importCompetition)
        {
            var queryBuilder = new QueryBuilder
            {
                { "IdCompetition", importCompetition.CompetitionId.ToString() },
                { "IdSeason", importCompetition.SeasonId.ToString() }
            };
            if (importCompetition.StageId.HasValue)
            {
                queryBuilder.Add("idStage", importCompetition.StageId.Value.ToString());
            }
            var response = await _client.GetJsonAsync<FifaResponse<Model.FIFA.Match>>($"https://api.fifa.com/api/v1/calendar/matches?{queryBuilder.ToQueryString()}");

            if (!response.Results.Any())
            {
                return;
            }

            var competitionId = $"{importCompetition.CompetitionId}/{importCompetition.SeasonId}";
            var competitionResponses = await _awsJsInterop.GraphQlAsync<CompetitionResponses>(FootballChampionship.Model.Queries.GET_COMPETITION, new { id = competitionId });
            var competition = competitionResponses.GetCompetition;
            if (competition == null)
            {
                competition = new Competition();
            }

            var matchesResponse = await _awsJsInterop.GraphQlAsync<MatchesResponse>(FootballChampionship.Model.Queries.LIST_MATCH,
            new
            {
                Filter = new
                {
                    MatchCompetitionId = new
                    {
                        Eq = competition.Id
                    }
                },
                Limit = 1000
            });

            var importedMatchList = matchesResponse.ListMatchs.Items.OrderBy(m => m.BeginAt);
            matchesResponse.ListMatchs.Items = importedMatchList;

            var mutation = competition.Id == null ? Model.Mutations.CREATE_COMPETITION : Model.Mutations.UPDATE_COMPETITION;
            
            var matches = response.Results.OrderBy(r => r.Date);
            var firstMatch = matches.First();
            var lastMatch = matches.Last();

            DateTime fromDate = firstMatch.Date;
            DateTime toDate = lastMatch.Date;
            if (importedMatchList.Any())
            {
                var firstDate = importedMatchList.First().BeginAt;
                fromDate = firstDate < fromDate ? firstDate : fromDate;
                var lastDate = importedMatchList.Last().BeginAt;
                toDate = lastDate > toDate ? lastDate : toDate;
            }

            competitionResponses = await _awsJsInterop.GraphQlAsync<CompetitionResponses>(mutation, new
            {
                input = new
                {
                    Id = competitionId,
                    Title = firstMatch.CompetitionName.First().Description,
                    From =  firstMatch.Date.ToAwsDate(),
                    To = lastMatch.Date > competition.To ? lastMatch.Date.ToAwsDate() : competition.To.Date.ToAwsDate(),
                    localizedNames = firstMatch.CompetitionName.Select(n => new LocalizedName { Locale = n.Locale, Value = n.Description })
                }
            });

            competition = competition.Id == null ? competitionResponses.CreateCompetition : competitionResponses.UpdateCompetition;

            competition.Matches = matchesResponse.ListMatchs;
            competition.Matches.Items = competition.Matches.Items.ToList();

            CompetitionUpdated?.Invoke(competition);

            foreach (var match in matches)
            {
                await UpdateMatch(competition, match);
            }

            await UpdateMatches(competitionId, competition, queryBuilder, "fr-FR");
            await UpdateMatches(competitionId, competition, queryBuilder, "de-DE");
        }

        private async Task UpdateMatches(string competitionId, Competition competition, QueryBuilder queryBuilder, string language)
        {
            var qb = new QueryBuilder(queryBuilder)
            {
                { "language", language }
            };

            var response = await _client.GetJsonAsync<FifaResponse<Model.FIFA.Match>>($"https://api.fifa.com/api/v1/calendar/matches?{qb.ToQueryString()}");
            var matches = response.Results.OrderBy(r => r.Date);
            var firstMatch = matches.First();

            competition.LocalizedNames = competition.LocalizedNames.Concat(
                            firstMatch.CompetitionName.Select(n => new LocalizedName { Locale = n.Locale, Value = n.Description })
                        )
                        .Distinct(_localizedNameComparer);

            var competitionResponses = await _awsJsInterop.GraphQlAsync<CompetitionResponses>(Model.Mutations.UPDATE_COMPETITION, new
            {
                input = new
                {
                    Id = competitionId,
                    localizedNames = competition.LocalizedNames
                }
            });
           
            foreach (var match in matches)
            {
                await UpdateMatch(competition, match);
            }
        }
        private async Task UpdateMatch(Competition competition, Model.FIFA.Match fifaMatch)
        {
            var homeTeam = await GetOrCreateTeam(fifaMatch.Home);
            var awayTeam = await GetOrCreateTeam(fifaMatch.Away);

            var localizedNames = fifaMatch.StageName.Select(n => new LocalizedName { Locale = n.Locale, Value = n.Description });
            var group = fifaMatch.GroupName.Select(n => new LocalizedName { Locale = n.Locale, Value = n.Description });
            var mutation = Model.Mutations.CREATE_MATCH;
            var savedMatch = competition.Matches.Items.FirstOrDefault(i => i.Id == fifaMatch.IdMatch);
            if (savedMatch != null)
            {
                savedMatch.LocalizedNames = savedMatch.LocalizedNames ?? new List<LocalizedName>();
                localizedNames = savedMatch.LocalizedNames
                    .Concat(localizedNames)
                    .Distinct(_localizedNameComparer);
                group = savedMatch.Group
                    .Concat(group)
                    .Distinct(_localizedNameComparer);
                mutation = Model.Mutations.UPDATE_MATCH;
            }
            
            var matchResponses = await _awsJsInterop.GraphQlAsync<MatchResponses>(mutation, new
            {
                input = new
                {
                    id = fifaMatch.IdMatch,
                    group,
                    number = fifaMatch.MatchNumber,
                    matchCompetitionId = competition.Id,
                    beginAt = fifaMatch.Date,
                    placeHolderHome = homeTeam?.Name ?? fifaMatch.PlaceHolderA,
                    placeHolderAway = awayTeam?.Name ?? fifaMatch.PlaceHolderB,
                    localizedNames
                }
            });

            var match = matchResponses.CreateMatch ?? matchResponses.UpdateMatch;
            if (savedMatch != null)
            {
                savedMatch.BeginAt = match.BeginAt;
                savedMatch.Group = match.Group;
                savedMatch.LocalizedNames = match.LocalizedNames;
                savedMatch.MatchTeams = match.MatchTeams;
                savedMatch.Number = match.Number;
                savedMatch.PlaceHolderAway = match.PlaceHolderAway;
                savedMatch.PlaceHolderHome = match.PlaceHolderHome;                
            }
            else
            {
                var matchList = (IList<FootballChampionship.Model.Match>) competition.Matches.Items;
                matchList.Add(match);
            }

            var matchTeams = match.MatchTeams.Items;

            MatchTeam homeMatchTeam = null;
            if (homeTeam != null)
            {
                homeMatchTeam = matchTeams.FirstOrDefault(mt => mt.Team.Id == homeTeam.Id);
                if (homeMatchTeam == null)
                {
                    var homeMatchTeamResponse = await _awsJsInterop.GraphQlAsync<MatchTeamResponses>(Model.Mutations.CREATE_MATCH_TEAM, new
                    {
                        input = new
                        {
                            id = Guid.NewGuid(),
                            isHome = true,
                            matchTeamTeamId = homeTeam.Id,
                            matchTeamMatchId = fifaMatch.IdMatch
                        }
                    });
                    homeMatchTeam = homeMatchTeamResponse.CreateMatchTeam;
                }

                homeMatchTeam.Team = homeTeam;
            }

            MatchTeam awayMatchTeam = null;
            if (awayTeam != null)
            {
                awayMatchTeam = matchTeams.FirstOrDefault(mt => mt.Team.Id == awayTeam.Id);
                if (awayMatchTeam == null)
                {
                    var awayMatchTeamResponse = await _awsJsInterop.GraphQlAsync<MatchTeamResponses>(Model.Mutations.CREATE_MATCH_TEAM, new
                    {
                        input = new
                        {
                            id = Guid.NewGuid(),
                            isHome = false,
                            matchTeamTeamId = awayTeam.Id,
                            matchTeamMatchId = fifaMatch.IdMatch
                        }
                    });
                    awayMatchTeam = awayMatchTeamResponse.CreateMatchTeam;
                }
                awayMatchTeam.Team = awayTeam;
            }

            match.MatchTeams.Items = new List<MatchTeam>
            {
                homeMatchTeam,
                awayMatchTeam
            };

            MatchUpdated?.Invoke(match);
        }

        private async Task<FootballChampionship.Model.Team> GetOrCreateTeam(Model.FIFA.Team team)
        {
            if (team == null)
            {
                return null;
            }

            var teamResponse = await _awsJsInterop.GraphQlAsync<TeamResponses>(Model.Queries.GET_TEAM, new { id = team.IdTeam });
            var savedTeam = teamResponse.GetTeam;
            if (savedTeam?.Id == null)
            {
                teamResponse = await _awsJsInterop.GraphQlAsync<TeamResponses>(Model.Mutations.CREATE_TEAM, new
                {
                    input = new
                    {
                        id = team.IdTeam,
                        name = team.TeamName.First().Description,
                        localizedNames = team.TeamName.Select(n => new LocalizedName { Locale = n.Locale, Value = n.Description})
                    }
                });
                savedTeam = teamResponse.CreateTeam;
            }
            else
            {
                savedTeam.LocalizedNames = savedTeam.LocalizedNames ?? new List<LocalizedName>();
                teamResponse = await _awsJsInterop.GraphQlAsync<TeamResponses>(Model.Mutations.UPDATE_TEAM, new
                {
                    input = new
                    {
                        id = team.IdTeam,
                        localizedNames = savedTeam.LocalizedNames.Concat(team.TeamName
                            .Select(n => new LocalizedName { Locale = n.Locale, Value = n.Description }))
                            .Distinct(_localizedNameComparer)
                    }
                });
                savedTeam = teamResponse.UpdateTeam;
            }

            return savedTeam;
        }

        class LocalizedNameComparer : IEqualityComparer<LocalizedName>
        {
            public bool Equals(LocalizedName x, LocalizedName y)
            {
                return x.Locale == y.Locale;
            }

            public int GetHashCode(LocalizedName obj)
            {
                return -1;
            }
        }
    }
}
