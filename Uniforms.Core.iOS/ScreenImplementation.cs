using System;
using UIKit;
using Uniforms.Core.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(ScreenImplementation))]

namespace Uniforms.Core.iOS
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
            size = new Xamarin.Forms.Size(
                UIScreen.MainScreen.Bounds.Width,
                UIScreen.MainScreen.Bounds.Height
            );
        }
    }
}

