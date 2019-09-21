using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Aguacongas.AwsServices
{
    public class AwsJsInterop : IAwsJsInterop
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly IAwsHelper _awsHelper;

        private bool configured;
        private bool listing;

        public AwsJsInterop(IJSRuntime jSRuntime, IAwsHelper awsHelper)
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
                    DotNetObjectReference.Create(_awsHelper)
                ).AsTask();
            }
            return Task.CompletedTask;
        }

        public Task ConfigureAsync(AwsConfig config)
        {
            if (!configured)
            {
                configured = true;
                return _jsRuntime.InvokeAsync<object>(
                    "amplifyWrapper.configure",
                    config)
                    .AsTask();
            }
            return Task.CompletedTask;
        }

        public Task SignInAsync(string provider = null)
        {
            return _jsRuntime.InvokeAsync<object>(
                "amplifyWrapper.auth.federatedSignIn",
                provider)
                .AsTask();
        }

        public Task SignOutAsync()
        {
            return _jsRuntime.InvokeAsync<object>("amplifyWrapper.auth.signout",
                DotNetObjectReference.Create(_awsHelper))
                .AsTask();
        }

        public async Task<TResponse> GraphQlAsync<TResponse>(string operation, object parameters = null)
        {
            var result = await _jsRuntime
                .InvokeAsync<GraphQlData<TResponse>>("amplifyWrapper.graphql.operation",
                    operation,
                    parameters);
            return result.Data;
        }

        public Task GraphSubscribeAsync<THelper>(string operation, THelper helper, string callback) where THelper: class
        {
            return _jsRuntime
                .InvokeAsync<object>("amplifyWrapper.graphql.subsription",
                    operation,
                    DotNetObjectReference.Create(helper),
                    callback)
                .AsTask();
        }
    }
}
