using System.Collections.Generic;

namespace Aguacongas.AwsServices
{
    public class AwsCookieStorage
    {
        public string Domain { get; set; }

        public string Path { get; set; }

        public int Expires { get; set; }

        public bool Secure { get; set; }
    }

    public class AwsOAuth
    {
        public string Domain { get; set; }
        public IEnumerable<string> Scope { get; set; }
        public string RedirectSignIn { get; set; }
        public string RedirectSignOut { get; set; }
        public string ResponseType { get; set; }

        public bool? MandatorySignIn { get; set; }

        public string UserPoolWebClientId { get; set; }

        public string IdentityPoolId { get; set; }

        public string Region { get; set; }

        public string IdentityPoolRegion { get; set; }

        public AwsCookieStorage CookieStorage  { get; set; }

        public object Storage { get; set; }
        public string AuthenticationFlowType { get; set; }
    }

    public class AwsConfig
    {
        public string Aws_cognito_identity_pool_id { get; set; }

        public string Aws_cognito_region { get; set; }

        public string Aws_user_pools_id { get; set; }

        public string Aws_user_pools_web_client_id { get; set; }

        public AwsOAuth Oauth { get; set; } // SimpleJson used in Blazor do not allow us to name it OAuth

        public string FederationTarget { get; set; }
        public string Aws_appsync_graphqlEndpoint { get; set; }
        public string Aws_appsync_region { get; set; }
        public string Aws_appsync_authenticationType { get; set; }

        public string Aws_appsync_apiKey { get; set; }
    }
}
