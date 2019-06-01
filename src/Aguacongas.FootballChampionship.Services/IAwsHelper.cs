using System;

namespace Aguacongas.FootballChampionship.Services
{
    public interface IAwsHelper
    {
        bool Initialized { get; }
        bool IsConnected { get; }
        AwsUser User { get; }
        string UserName { get; }

        event EventHandler<EventArgs> UserChanged;

        void SetUser(AwsUser user);
    }
}