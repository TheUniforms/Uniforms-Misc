using System;
using System.IO;
using UIKit;
using Uniforms.Core.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(ImageUtilsImplementation))]

namespace Uniforms.Core.iOS
{
    public class ImageUtilsImplementation : IImageUtils
    {
        internal static void Init() {}

        #region IImageUtils implementation

        public Xamarin.Forms.Size GetImageSize(string name)
        {
            UIImage image = UIImage.FromFile(name);

            return new Xamarin.Forms.Size(
                (double)image.Size.Width,
                (double)image.Size.Height);
        }
            
        public Stream ResizeImage(Stream imageData, double width, double height,
            string format = "jpeg", int quality = 96)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

