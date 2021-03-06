﻿using Aguacongas.AwsServices;
using Microsoft.AspNetCore.Components;
using System;

namespace Aguacongas.AwsComponents
{
    public class LoginHeaderModel : ComponentBase, IDisposable
    {
        private IAwsHelper _awsHelper;

        [Inject]
        public IAwsHelper AwsHelper
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
