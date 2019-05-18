using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aguacongas.FootballChampionship.Components
{
    public class AwsJsInterop
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly AwsHelper _awsHelper;

        private bool configured;
        private bool listing;

        public AwsJsInterop(IJSRuntime jSRuntime, AwsHelper awsHelper)
        {
            _jsRuntime = jSRuntime;
            _awsHelper = awsHelper;
        }

        public Task ListenAsync()
        {
            if (!listing)
            {
                listing = true;
                return _jsRuntime.InvokeAsync<object>(
                    "amplifyWrapper.hub.listen",
                    new DotNetObjectRef(_awsHelper)
                );
            }
            return Task.CompletedTask;
        }

        public Task ConfigureAsync()
        {
            if (!configured)
            {
                configured = true;
                return _jsRuntime.InvokeAsync<object>(
                    "amplifyWrapper.configure");
            }
            return Task.CompletedTask;
        }

        public Task SignInAsync(string provider = null)
        {
            return _jsRuntime.InvokeAsync<object>(
                "amplifyWrapper.auth.federatedSignIn",
                provider);
        }

        public Task SignOutAsync()
        {
            return _jsRuntime.InvokeAsync<object>("amplifyWrapper.auth.signout", _awsHelper);
        }
    }
}
