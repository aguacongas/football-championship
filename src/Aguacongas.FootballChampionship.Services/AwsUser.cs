using System;
using System.Collections.Generic;
using System.Text;

namespace Aguacongas.FootballChampionship.Services
{
    public class Client
    {
        public string endpoint { get; set; }
        public string userAgent { get; set; }
    }

    public class Pool
    {
        public string UserPoolId { get; set; }
        public string ClientId { get; set; }
        public Client Client { get; set; }
        public bool AdvancedSecurityDataCollectionFlag { get; set; }
    }

    public class Identity
    {
        public string UserId { get; set; }
        public string ProviderName { get; set; }
        public string ProviderType { get; set; }
        public object Issuer { get; set; }
        public string Primary { get; set; }
        public string DateCreated { get; set; }
    }

    public class Payload
    {
        public string at_hash { get; set; }
        public string Sub { get; set; }
        public List<string> Groups { get; set; }
        public string Iss { get; set; }
        public string Username { get; set; }
        public string Aud { get; set; }
        public List<Identity> Identities { get; set; }
        public string Token_use { get; set; }
        public int Auth_time { get; set; }
        public string Name { get; set; }
        public int Exp { get; set; }
        public int Iat { get; set; }
        public string Email { get; set; }
    }

    public class IdToken
    {
        public Payload Payload { get; set; }
    }
    public class SignInUserSession
    {
        public IdToken IdToken { get; set; }
    }

    public class Attributes
    {
        public string Sub { get; set; }
        public string Identities { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class AwsUser
    {
        public string Username { get; set; }
        public Pool Pool { get; set; }
        public Client Client { get; set; }
        public SignInUserSession SignInUserSession { get; set; }
        public string AuthenticationFlowType { get; set; }
        public string KeyPrefix { get; set; }
        public string UserDataKey { get; set; }
        public Attributes Attributes { get; set; }
        public string PreferredMFA { get; set; }
    }
}
