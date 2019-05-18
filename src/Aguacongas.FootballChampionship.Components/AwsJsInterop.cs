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

        public AwsJsInterop(IJSRuntime jSRuntime, AwsHelper awsHelper)
        {
            _jsRuntime = jSRuntime;
            _awsHelper = awsHelper;
        }

        public Task ListenAsync()
        {
            return _jsRuntime.InvokeAsync<object>(
                "amplifyWrapper.hub.listen",
                new DotNetObjectRef(_awsHelper)
            );
        }

        public Task ConfigureAsync()
        {
            return _jsRuntime.InvokeAsync<object>(
                "amplifyWrapper.configure");
        }

        public Task SignInAsync(string provider = null)
        {
            return _jsRuntime.InvokeAsync<object>(
                "amplifyWrapper.auth.federatedSignIn",
                provider);
        }
    }
}
