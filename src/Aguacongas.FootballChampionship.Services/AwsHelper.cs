using Microsoft.JSInterop;
using System;

namespace Aguacongas.FootballChampionship.Services
{
    public class AwsHelper : IAwsHelper
    {
        public bool Initialized { get; private set; }
        public string UserName { get; private set; }

        public AwsUser User { get; private set; }

        public bool IsConnected { get; private set; }

        public event EventHandler<EventArgs> UserChanged;

        [JSInvokable]
        public void SetUser(AwsUser user)
        {
            Initialized = true;
            User = user;
            UserName = user?.Attributes.Name ?? user?.Attributes.Email;
            IsConnected = user != null;
            UserChanged?.Invoke(this, new EventArgs());
            Console.WriteLine(Json.Serialize(user));
        }
    }
}
