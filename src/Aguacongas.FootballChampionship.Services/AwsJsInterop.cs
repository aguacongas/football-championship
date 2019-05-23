using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aguacongas.FootballChampionship.Services
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

        public async Task<TResponse> GraphQlAsync<TResponse>(string operation, object parameters)
        {
            var result = await  _jsRuntime
                .InvokeAsync<GraphQlResponse<TResponse>>("amplifyWrapper.graphql.operation",
                    operation,
                    parameters);
            Console.WriteLine(Json.Serialize(result));
            return result.Data;
        }

        public async Task GraphSubscribeAsync<THelper>(string operation, THelper helper, string callback)
        {
            await _jsRuntime
                .InvokeAsync<object>("amplifyWrapper.graphql.operation",
                    operation,
                    helper,
                    callback);
        }
        class GraphQlResponse<T>
        {
            public T Data { get; set; }
        }
    }
}
