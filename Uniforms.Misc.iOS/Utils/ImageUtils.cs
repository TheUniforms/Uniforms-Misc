using System;
using System.IO;
using UIKit;
using Uniforms.Misc.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(ImageUtils))]

namespace Uniforms.Misc.iOS
{
    public class ImageUtils : IImageUtils
    {
        /// <summary>
        /// Initialize platform implementation for image utils.
        /// </summary>
        public static void Init()
        {
            Misc.ImageUtils.Init (new ImageUtils ());
        }

        #region IImageUtils implementation

        public Xamarin.Forms.Size GetImageSize(string name)
        {
            UIImage image = UIImage.FromFile(name);

            return new Xamarin.Forms.Size(
                (double)image.Size.Width,
                (double)image.Size.Height);
        }
            
        public Stream ResizeImage(
            Stream imageData,
            double width,
            double height,
            string format = "jpeg",
            int quality = 96)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

