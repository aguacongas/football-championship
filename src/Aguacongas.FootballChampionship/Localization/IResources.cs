using System;
using System.Collections.Generic;

namespace Aguacongas.FootballChampionship.Localization
{
    public interface IResources
    {
        string this[string key] { get; }

        int Count { get; }
        IEnumerable<string> Keys { get; }
        IEnumerable<string> Values { get; }

        event EventHandler<EventArgs> CultureChanged;

        bool ContainsKey(string key);
        IEnumerator<KeyValuePair<string, string>> GetEnumerator();
        void SetCulture(string name);
        bool TryGetValue(string key, out string value);
    }
}