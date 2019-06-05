using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace Aguacongas.FootballChampionship.Localization
{
    public class Resources : IReadOnlyDictionary<string, string>, IResources
    {
        private readonly Dictionary<string, Dictionary<string, string>> _resources;
        private Dictionary<string, string> _currentResources;

        public event EventHandler<EventArgs> CultureChanged;

        public IEnumerable<string> Keys => GetInternalDictionary().Keys;

        public IEnumerable<string> Values => GetInternalDictionary().Values;

        public int Count => GetInternalDictionary().Count;

        public string this[string key] => GetInternalDictionary()[key];

        public Resources()
        {
            _resources = new Dictionary<string, Dictionary<string, string>>
            {
                { "fr-FR", new Dictionary<string, string>
                    {
                        { "Loading...", "Chargement..." },
                        { "Login with Google", "Se connecter avec Google" },
                        { "Login with Facebook", "Se connecter avec Facebook" },
                        { "Login with Microsoft", "Se connecter avec Microsoft" },
                        { "Login with Amazon", "Se connecter avec Amazon" },
                        { "Hello {0}!", "Bonjour {0}!" },
                        { "Logout", "Se déconnecter" },
                        { "Competition", "Compétition" },
                        { "Import competition", "Importer une competition" },
                        { "Import a competition from FIFA api", "Importer une compétition de l'api FIFA" },
                        { "Title", "Titre" },
                        { "From", "Du" },
                        { "To", "Au" }
                    }
                },
                { "de-DE", new Dictionary<string, string>
                    {
                        { "Loading...", "Laden..." },
                        { "Login with Google", "Mit Google einloggen" },
                        { "Login with Facebook", "Mit Facebook einloggen" },
                        { "Login with Microsoft", "Mit Microsoft einloggen" },
                        { "Login with Amazon", "Mit Amazon einloggen" },
                        { "Hello {0}!", "Hallo {0}!" },
                        { "Logout", "Ausloggen" },
                        { "Competition", "Wettbewerb" },
                        { "Import competition", "Importwettbewerb" },
                        { "Import a competition from FIFA api", "Importieren Sie einen Wettbewerb von FIFA api" },
                        { "Title", "Titel" },
                        { "From", "Vom" },
                        { "To", "Bis" }
                    }
                }
            };

            SetCulture("en-GB");
        }

        public bool ContainsKey(string key)
        => GetInternalDictionary().ContainsKey(key);

        public bool TryGetValue(string key, out string value)
        => GetInternalDictionary().TryGetValue(key, out value);

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        => GetInternalDictionary().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        => GetInternalDictionary().GetEnumerator();

        public void SetCulture(string name)
        {
            var culture = CultureInfo.CreateSpecificCulture(name);
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            _currentResources = null;

            CultureChanged?.Invoke(this, new EventArgs());
        }

        private Dictionary<string, string> GetInternalDictionary()
        {
            if (_currentResources != null)
            {
                return _currentResources;
            }

            var cultureName = CultureInfo.DefaultThreadCurrentUICulture.ToString();
            
            _currentResources = new Dictionary<string, string>(_resources.SelectMany(r => 
                r.Value.Select(v => v.Key))
                .Distinct()
                .ToDictionary(d => d));

            if (_resources.ContainsKey(cultureName))
            {
                var localized = _resources[cultureName];
                foreach (var key in localized.Keys)
                {
                    _currentResources[key] = localized[key];
                }
            }

            return _currentResources;
        }
    }
}
