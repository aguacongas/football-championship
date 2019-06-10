using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Aguacongas.FootballChampionship.Interop
{
    public enum ScrollBehavior
    {
        Auto,
        Smooth
    }
    public enum ScrollPosition
    {
        Start,
        Center,
        End,
        Nearest
    }
    public class BrowserJsInterop : IBrowserJsInterop
    {
        private readonly IJSRuntime _jsRuntime;

        public BrowserJsInterop(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }
        public Task<string> GetLanguage()
        {
            return _jsRuntime.InvokeAsync<string>("browserJsFunctions.getLanguage");
        }

        public Task SetItem<T>(string key, T value)
        {
            return _jsRuntime.InvokeAsync<object>(
                "browserJsFunctions.storage.setItem",
                key,
                value);
        }

        public Task<T> GetItem<T>(string key)
        {
            return _jsRuntime.InvokeAsync<T>(
                "browserJsFunctions.storage.getItem",
                key);
        }

        public Task<string> GetPathName()
        {
            return _jsRuntime.InvokeAsync<string>("browserJsFunctions.location.pathname");
        }

        public Task<bool> ScrollElementIntoView(string elementId, ScrollBehavior? behavior = null, ScrollPosition? block = null, ScrollPosition? inline = null)
        {
            return _jsRuntime.InvokeAsync<bool>("browserJsFunctions.scrollElementIntoView",
                elementId,
                behavior?.ToString(),
                block?.ToString(),
                inline?.ToString());
        }

        public Task NotificationOptIn()
        {
            return _jsRuntime.InvokeAsync<object>("browserJsFunctions.notification.requestPermission");
        }

        public Task Notify(string title, string message)
        {
            return _jsRuntime.InvokeAsync<object>("browserJsFunctions.notification.notify", title, message);
        }
    }
}
