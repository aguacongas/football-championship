using Aguacongas.FootballChampionship.Model;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Aguacongas.FootballChampionship
{
    public static class LocalizedNamesExtensions
    {
        public static string GetLocalizedValue(this IEnumerable<LocalizedName> names)
        {
            if (names == null)
            {
                return null;
            }

            var cultureName = CultureInfo.DefaultThreadCurrentUICulture.ToString();
            var name = names.FirstOrDefault(n => n.Locale == cultureName);
            if (name == null)
            {
                return names.FirstOrDefault(n => n.Locale == "en-GB")?.Value;
            }

            return name.Value;
        }
    }
}
