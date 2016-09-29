using System;
using UIKit;
using Uniforms.Misc.iOS;

namespace Uniforms.Misc.iOS
{
    public static class ScreenUtils
    {
        public static void Init ()
        {
            Misc.ScreenUtils.ScreenSize = new Xamarin.Forms.Size(
                UIScreen.MainScreen.Bounds.Width,
                UIScreen.MainScreen.Bounds.Height
            );
        }
    }
}

