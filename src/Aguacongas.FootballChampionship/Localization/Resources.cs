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
                        { "Login with", "Connecte toi avec" },
                        { "Hello {0}!", "Bonjour {0}!" },
                        { "Logout", "Se déconnecter" },
                        { "Competition", "Compétition" },
                        { "Import competition", "Importer une competition" },
                        { "Import a competition from FIFA api", "Importer une compétition de l'api FIFA" },
                        { "Title", "Titre" },
                        { "From", "Du" },
                        { "To", "Au" },
                        { "The score for {0} is required.", "Le score pour {0} est requise" },
                        { "If you find the match score you win", "Si tu trouves le score du match tu gagnes" },
                        { "If you find the winner of the match you win", "Si tu trouves le vainqueur du match tu gagnes" },
                        { "You can predict until kick-off. Shootout sessions are not counted.", "Tu peux pronostiquer jusqu'au coup d'envoi. Les séances de tirs au but ne sont pas comptabilisées." },
                        { "1st wins", "Le 1er gagne" },
                        { "all my esteem", "toute mon estime" },
                        { "Prognosis for butter.", "Pronostique pour du beurre." }
                    }
                },
                { "de-DE", new Dictionary<string, string>
                    {
                        { "Loading...", "Laden..." },
                        { "Login with", "Verbinden Sie sich mit" },
                        { "Hello {0}!", "Hallo {0}!" },
                        { "Logout", "Ausloggen" },
                        { "Competition", "Wettbewerb" },
                        { "Import competition", "Importwettbewerb" },
                        { "Import a competition from FIFA api", "Importieren Sie einen Wettbewerb von FIFA api" },
                        { "Title", "Titel" },
                        { "From", "Vom" },
                        { "To", "Bis" },
                        { "The score for {0} is required.", "Die Punktzahl für {0} ist erforderlich" },
                        { "If you find the match score you win", "Wenn Sie das Matchergebnis finden, gewinnen Sie" },
                        { "3 points", "3 Punkte" },
                        { "If you find the winner of the match you win", "Wenn Sie den Sieger des Spiels finden, gewinnen Sie" },
                        { "1 point", "1 Punkt" },
                        { "You can predict until kick-off. Shootout sessions are not counted.", "Sie können bis zum Anpfiff vorhersagen. Shootout-Sessions werden nicht gezählt." },
                        { "1st wins", "1. gewinnt" },
                        { "all my esteem", "meine ganze Wertschätzung" },
                        { "Prognosis for butter.", "Prognose für Butter." }
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
