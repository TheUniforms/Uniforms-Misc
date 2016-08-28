using System;
using System.Globalization;
using Foundation;
using Uniforms.Core.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(LocalizeImplementation))]

namespace Uniforms.Core.iOS
{
    public class LocalizeImplementation : ILocalize
    {
        internal static void Init() {}

        const string defaultLocale = "en";

        #region ILocalize implementation

        public CultureInfo GetCurrentCultureInfo(bool dialect = false)
        {
            var currentLocale = defaultLocale;

            if (NSLocale.PreferredLanguages.Length > 0)
            {
                var lang = NSLocale.PreferredLanguages[0];
                currentLocale = lang.Split('-')[0];
            }

            return new CultureInfo(currentLocale);
        }

        #endregion
    }
}

