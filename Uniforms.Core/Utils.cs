using System;
using System.Globalization;
using Xamarin.Forms;

namespace Uniforms.Core
{
    public static class Utils
    {
        static IScreen screen;

        static ILocalize localize;

        static IImageUtils imageUtils;

        public static void Init()
        {
            screen = DependencyService.Get<IScreen>();

            localize = DependencyService.Get<ILocalize>();

            imageUtils = DependencyService.Get<IImageUtils>();
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

        public static Size GetImageSize(string name)
        {
            return imageUtils.GetImageSize(name);
        }
    }
}

