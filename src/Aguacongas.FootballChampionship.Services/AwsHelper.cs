﻿using Microsoft.JSInterop;
using System;

namespace Aguacongas.FootballChampionship.Services
{
    public class AwsHelper
    {
        public bool Initialized { get; private set; }
        public string UserName { get; private set; }

        public bool IsConnected { get; private set; }

        public event EventHandler<EventArgs> UserChanged;

        [JSInvokable]
        public void SetUser(string userName)
        {
            Initialized = true;
            UserName = userName;
            IsConnected = !string.IsNullOrEmpty(userName);
            UserChanged?.Invoke(this, new EventArgs());
        }
    }
}
