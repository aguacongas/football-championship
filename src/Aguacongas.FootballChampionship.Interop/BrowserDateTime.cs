using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Aguacongas.FootballChampionship.Interop
{
    public class BrowserDateTime : IBrowserDateTime
    {
        private readonly IJSRuntime _jsRuntime;
        private TimeZoneInfo _timeZoneInfo;

        public BrowserDateTime(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<DateTime> ToBrowerTime(DateTime dateTime)
        {
            if (_timeZoneInfo == null)
            {
                var timeZoneOffSet = await _jsRuntime.InvokeAsync<int>("browserJsFunctions.getBrowserTimeZoneOffset");
                var browserTimeZoneIdentifier = await _jsRuntime.InvokeAsync<string>("browserJsFunctions.getBrowserTimeZoneIdentifier");
                var timeZoneIdentifier = string.IsNullOrWhiteSpace(browserTimeZoneIdentifier) ? "BrowserTZ" : browserTimeZoneIdentifier;
                _timeZoneInfo = TimeZoneInfo.CreateCustomTimeZone(timeZoneIdentifier, new TimeSpan(0, 0 - timeZoneOffSet, 0), timeZoneIdentifier, timeZoneIdentifier);
            }

            return TimeZoneInfo.ConvertTime(dateTime, _timeZoneInfo);
        }
    }
}
