using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Aguacongas.FootballChampionship.Interop
{
    public class BrowserJsInterop : IBrowserJsInterop
    {
        private readonly IJSRuntime _jsRuntime;

        public BrowserJsInterop(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }
        public async Task<string> GetLanguage()
        {
            return await _jsRuntime.InvokeAsync<string>("browserJsFunctions.getLanguage");
        }

        public async Task SetItem<T>(string key, T value)
        {
            await _jsRuntime.InvokeAsync<object>(
                "browserJsFunctions.storage.setItem",
                key,
                value);
        }

        public async Task<T> GetItem<T>(string key)
        {
            return await _jsRuntime.InvokeAsync<T>(
                "browserJsFunctions.storage.getItem",
                key);
        }

        public async Task<string> GetPathName()
        {
            return await _jsRuntime.InvokeAsync<string>("browserJsFunctions.location.pathname");
        }

        public async Task<int> GetBrowserTimeZoneOffset()
        {
            return await _jsRuntime.InvokeAsync<int>("browserJsFunctions.getBrowserTimeZoneOffset");
        }

        public async Task<string> GetBrowserTimeZoneIdentifier()
        {
            return await _jsRuntime.InvokeAsync<string>("browserJsFunctions.getBrowserTimeZoneIdentifier");
        }
    }
}
