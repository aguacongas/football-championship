using Microsoft.JSInterop;

namespace Aguacongas.FootballChampionship.Components
{
    public class AwsHelper
    {
        public string UserName { get; private set; }
        public string Token { get; private set; }

        [JSInvokable]
        public void SetUser(string userName, string token)
        {
            UserName = userName;
            Token = token;
        }
    }
}
