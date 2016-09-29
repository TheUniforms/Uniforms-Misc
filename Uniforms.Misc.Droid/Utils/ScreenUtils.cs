using System;
using Uniforms.Misc.Droid;

namespace Uniforms.Misc.Droid
{
    public static class ScreenUtils
    {
        public static void Init ()
        {
            var display = Xamarin.Forms.Forms.Context.Resources.DisplayMetrics;
            Misc.ScreenUtils.ScreenSize = new Xamarin.Forms.Size (
                display.WidthPixels / display.Density,
                display.HeightPixels / display.Density
            );
        }
    }
}

