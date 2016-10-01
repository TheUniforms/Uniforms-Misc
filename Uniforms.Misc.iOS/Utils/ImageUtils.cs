using System;
using System.IO;
using UIKit;
using CoreGraphics;
using Foundation;
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

            var size = new Xamarin.Forms.Size(
                (double)image.Size.Width,
                (double)image.Size.Height);

            image.Dispose ();

            return size;
        }
            
        public Stream ResizeImage(
            Stream imageStream,
            double width,
            double height,
            string format = "jpeg",
            int quality = 96)
        {
            if (imageStream == null) {
                return null;
            }

            UIImage image = null;
            try {
                using (var memoryStream = new MemoryStream ()) {
                    imageStream.CopyTo (memoryStream);
                    var data = memoryStream.ToArray ();
                    image = UIImage.LoadFromData (NSData.FromArray (data));
                }
            } catch (Exception e) {
                Console.WriteLine ($"ResizeImage: {e.Message}");
                return null;
            }

            // No need to resize if required size is greater than original
            var scale = Math.Min (width / image.Size.Width,
                                  height / image.Size.Height);
            if (scale > 1.0) {
                return imageStream;
            }

            width = (float)(scale * image.Size.Width);
            height = (float)(scale * image.Size.Height);

            UIGraphics.BeginImageContextWithOptions (
                new CGSize (width, height),
                opaque: true,
                scale: 0);
            image.Draw (new CGRect (0, 0, width, height));
            var resized = UIGraphics.GetImageFromCurrentImageContext ();
            UIGraphics.EndImageContext ();

            var stream = new MemoryStream ();

            var resizeData = ((format == "png") ?
                              resized.AsPNG ().ToArray () :
                              resized.AsJPEG ((nfloat)(0.01 * quality)).ToArray ());

            image.Dispose ();
            resized.Dispose ();

            stream.Write (resizeData, 0, resizeData.Length);
            stream.Seek (0, SeekOrigin.Begin);
            return stream;
        }

        #endregion
    }
}

