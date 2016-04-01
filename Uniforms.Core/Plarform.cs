using System;
using System.Globalization;
using Xamarin.Forms;

namespace Uniforms.Core
{
    public static class Plarform
    {
        static IScreen screen;

        static ILocalize localize;

        public static void Init()
        {
            screen = DependencyService.Get<IScreen>();

            localize = DependencyService.Get<ILocalize>();
        }

        public static Size ScreenSize
        {
            get
            {
                return screen.Size;
            }
        }

        public static CultureInfo GetCurrentCultureInfo(bool region = false)
        {
            return localize.GetCurrentCultureInfo(region);
        }
    }
}

