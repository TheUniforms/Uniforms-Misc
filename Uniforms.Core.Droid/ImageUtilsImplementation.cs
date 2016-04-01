using System;
using Xamarin.Forms;
using Android.Graphics;
using Uniforms.Core.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(ImageUtilsImplementation))]

namespace Uniforms.Core.Droid
{
    using Path = System.IO.Path;

    public class ImageUtilsImplementation : IImageUtils
    {
        internal static void Init() {}

        #region IImageUtils implementation

        public Xamarin.Forms.Size GetImageSize(string name)
        {
            var display = Forms.Context.Resources.DisplayMetrics;
            var options = new BitmapFactory.Options {
                InJustDecodeBounds = true
            };
            var resId = Forms.Context.Resources.GetIdentifier(
                Path.GetFileNameWithoutExtension(name.Replace("-", "_")),
                "drawable", Forms.Context.PackageName);
            
            BitmapFactory.DecodeResource(
                Forms.Context.Resources, resId, options);

            return new Size(
                Math.Round((double)options.OutWidth / display.Density),
                Math.Round((double)options.OutHeight / display.Density));
        }

        #endregion
    }
}

