using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aguacongas.FootballChampionship.Admin.Model.FIFA
{
    public class StageName
    {
        public string Locale { get; set; }
        public string Description { get; set; }
    }

    public class GroupName
    {
        public string Locale { get; set; }
        public string Description { get; set; }
    }

    public class CompetitionName
    {
        public string Locale { get; set; }
        public string Description { get; set; }
    }

    public class SeasonName
    {
        public string Locale { get; set; }
        public string Description { get; set; }
    }

    public class TeamName
    {
        public string Locale { get; set; }
        public string Description { get; set; }
    }

    public class Team
    {
        public int Score { get; set; }
        public object Side { get; set; }
        public string IdTeam { get; set; }
        public string PictureUrl { get; set; }
        public string IdCountry { get; set; }
        public object Tactics { get; set; }
        public int TeamType { get; set; }
        public int AgeType { get; set; }
        public List<TeamName> TeamName { get; set; }
        public string Abbreviation { get; set; }
        public int FootballType { get; set; }
        public int Gender { get; set; }
        public string IdAssociation { get; set; }
    }

    public class Name
    {
        public string Locale { get; set; }
        public string Description { get; set; }
    }

    public class CityName
    {
        public string Locale { get; set; }
        public string Description { get; set; }
    }

    public class Properties
    {
        public string IdIFES { get; set; }
    }

    public class Stadium
    {
        public string IdStadium { get; set; }
        public List<Name> Name { get; set; }
        public object Capacity { get; set; }
        public object WebAddress { get; set; }
        public object Built { get; set; }
        public bool Roof { get; set; }
        public object Turf { get; set; }
        public string IdCity { get; set; }
        public List<CityName> CityName { get; set; }
        public string IdCountry { get; set; }
        public object PostalCode { get; set; }
        public object Street { get; set; }
        public object Email { get; set; }
        public object Fax { get; set; }
        public object Phone { get; set; }
        public object AffiliationCountry { get; set; }
        public object AffiliationRegion { get; set; }
        public object Latitude { get; set; }
        public object Longitude { get; set; }
        public object Length { get; set; }
        public object Width { get; set; }
        public Properties Properties { get; set; }
        public object IsUpdateable { get; set; }
    }

    public class Match
    {
        public string IdCompetition { get; set; }
        public string IdSeason { get; set; }
        public string IdStage { get; set; }
        public string IdGroup { get; set; }
        public object Weather { get; set; }
        public object Attendance { get; set; }
        public string IdMatch { get; set; }
        public object MatchDay { get; set; }
        public List<StageName> StageName { get; set; }
        public List<GroupName> GroupName { get; set; }
        public List<CompetitionName> CompetitionName { get; set; }
        public List<SeasonName> SeasonName { get; set; }
        public List<object> SeasonShortName { get; set; }
        public DateTime Date { get; set; }
        public DateTime LocalDate { get; set; }
        public Team Home { get; set; }
        public Team Away { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }

        public object HomeTeamScore { get; set; }
        public object AwayTeamScore { get; set; }
        public object AggregateHomeTeamScore { get; set; }
        public object AggregateAwayTeamScore { get; set; }
        public object HomeTeamPenaltyScore { get; set; }
        public object AwayTeamPenaltyScore { get; set; }
        public object LastPeriodUpdate { get; set; }
        public object Leg { get; set; }
        public object IsHomeMatch { get; set; }
        public Stadium Stadium { get; set; }
        public object IsTicketSalesAllowed { get; set; }
        public object MatchTime { get; set; }
        public object SecondHalfTime { get; set; }
        public object FirstHalfTime { get; set; }
        public object FirstHalfExtraTime { get; set; }
        public object SecondHalfExtraTime { get; set; }
        public object Winner { get; set; }
        public object MatchReportUrl { get; set; }
        public string PlaceHolderA { get; set; }
        public string PlaceHolderB { get; set; }
        public object BallPossession { get; set; }
        public List<object> Officials { get; set; }
        public int MatchStatus { get; set; }
        public int ResultType { get; set; }
        public int MatchNumber { get; set; }
        public bool TimeDefined { get; set; }
        public int OfficialityStatus { get; set; }
        public object MatchLegInfo { get; set; }
        public Properties Properties { get; set; }
        public object IsUpdateable { get; set; }
    }
}
