using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace SmartLeopard.Web.Helpers
{
    public static class CultureHelper
    {
        // Include ONLY cultures you are implementing
        private static readonly List<string> _cultures = new List<string>
        {
            "en-US",
            "es-ES",
        };

        public static IEnumerable<string> GetAllowedCultures()
        {
            return _cultures;
        }

        public static string GetImplementedCulture(string name)
        {
            if (string.IsNullOrEmpty(name))
                return GetDefaultCulture();

            if (_cultures.Any(c => c.Equals(name, StringComparison.InvariantCultureIgnoreCase)))
                return name;

            var neutralCulture = GetNeutralCulture(name);

            return _cultures.FirstOrDefault(c => c.StartsWith(neutralCulture)) ?? GetDefaultCulture();
        }

        public static string GetDefaultCulture()
        {
            return _cultures[0]; 
        }

        public static string GetCurrentCulture()
        {
            return Thread.CurrentThread.CurrentCulture.Name;
        }

        public static string GetCurrentNeutralCulture()
        {
            return GetNeutralCulture(Thread.CurrentThread.CurrentCulture.Name);
        }

        public static string GetNeutralCulture(string name)
        {
            return name.Contains("-") ? name.Split('-')[0] : name; // Read first part only. E.g. "en", "es"
        }
    }
}