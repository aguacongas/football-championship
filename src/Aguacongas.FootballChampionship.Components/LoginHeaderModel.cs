using Aguacongas.FootballChampionship.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aguacongas.FootballChampionship.Components
{
    public class LoginHeaderModel : ComponentBase, IDisposable
    {
        private AwsHelper _awsHelper;

        [Inject]
        public AwsHelper AwsHelper
        {
            get { return _awsHelper; }
            set
            {
                Unsubscribe();
                _awsHelper = value;
                _awsHelper.UserChanged += UserChanged;
            }
        }

        [Parameter]
        public string LogoutText { get; set; }

        [Parameter]
        public string GreetingTemplate { get; set; } = "Welcome {0}!";


        private void UserChanged(object sender, EventArgs e)
        {
            StateHasChanged();
        }

        private void Unsubscribe()
        {
            if (_awsHelper != null)
            {
                _awsHelper.UserChanged -= UserChanged;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Unsubscribe();
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion

    }
}
