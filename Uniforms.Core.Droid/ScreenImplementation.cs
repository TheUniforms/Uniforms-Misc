using System;
using Uniforms.Core.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(ScreenImplementation))]

namespace Uniforms.Core.Droid
{
    public class ScreenImplementation : IScreen
    {
        #region IScreen implementation

        public Xamarin.Forms.Size Size
        {
            get
            {
                return size;
            }
        }

        readonly Xamarin.Forms.Size size;

        #endregion

        public static void Init()
        {
            Screen.Init();
        }

        public ScreenImplementation()
        {
            var display = Xamarin.Forms.Forms.Context.Resources.DisplayMetrics;
            size = new Xamarin.Forms.Size(
                display.WidthPixels / display.Density,
                display.HeightPixels / display.Density
            );
        }
    }
}

