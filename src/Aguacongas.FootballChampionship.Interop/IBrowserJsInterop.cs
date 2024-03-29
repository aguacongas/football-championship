﻿using System.Threading.Tasks;

namespace Aguacongas.FootballChampionship.Interop
{
    public interface IBrowserJsInterop
    {
        Task<string> GetLanguage();

        Task SetItem<T>(string key, T value);

        Task<T> GetItem<T>(string key);

        Task<string> GetPathName();

        Task<bool> ScrollElementIntoView(string elementId, ScrollBehavior? behavior = null, ScrollPosition? block = null, ScrollPosition? inline = null);
        Task NotificationOptIn();
        Task Notify(string title, string message);
    }
}