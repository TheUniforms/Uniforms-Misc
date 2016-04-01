using System;
using System.Globalization;
using Uniforms.Core.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(LocalizeImplementation))]

namespace Uniforms.Core.Droid
{
    public class LocalizeImplementation : ILocalize
    {
        internal static void Init() {}

        const string defaultLocale = "en";

        #region ILocalize implementation

        public CultureInfo GetCurrentCultureInfo(bool region = false)
        {
            var androidLocale = Java.Util.Locale.Default;

            // turns pt_BR into pt-BR
            var currentLocale = androidLocale.ToString().Replace ("_", "-");

            if (String.IsNullOrEmpty(currentLocale))
            {
                currentLocale = defaultLocale;
            }

            if (!region)
            {
                currentLocale = currentLocale.Split('-')[0];
            }

            return new CultureInfo(currentLocale);
        }

        #endregion
    }
}

