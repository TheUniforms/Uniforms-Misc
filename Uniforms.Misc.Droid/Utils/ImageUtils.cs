using System;
using System.IO;
using Xamarin.Forms;
using Android.Graphics;
using Uniforms.Misc.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(ImageUtils))]

namespace Uniforms.Misc.Droid
{
    using Path = System.IO.Path;

    public class ImageUtils : IImageUtils
    {
        public static void Init()
        {
            Misc.ImageUtils.Init (new ImageUtils ());
        }

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

        public Stream ResizeImage(
            Stream imageData,
            double width,
            double height,
            string format = "jpeg",
            int quality = 96)
        {
            // Decode stream
            var options = new BitmapFactory.Options {
                InJustDecodeBounds = true
            };
            BitmapFactory.DecodeStream(imageData, null, options);
            imageData.Seek(0, SeekOrigin.Begin);

            var width0 = options.OutWidth;
            var height0 = options.OutHeight;

            // No need to resize
            if ((height >= height0) && (width >= width0))
            {
                return imageData;
            }

            // Calculate scale and sample size
            var scale = Math.Max(width / width0, height / height0);
            width = width0 * scale;
            height = height0 * scale;

            var inSampleSize = 1;
            while ((0.5 * height0 > inSampleSize * height) &&
                (0.5 * width0 > inSampleSize * width))
            {
                inSampleSize *= 2;
            }

            // Resize
            var originalImage = BitmapFactory.DecodeStream(imageData, null,
                new BitmapFactory.Options {
                InJustDecodeBounds = false,
                InSampleSize = inSampleSize
            });
            Bitmap resizedImage = Bitmap.CreateScaledBitmap(
                originalImage, (int)(width), (int)(height), false);
            originalImage.Recycle();

            // Compress
            var stream = new MemoryStream();
            Bitmap.CompressFormat imageFormat = (format == "png") ?
                Bitmap.CompressFormat.Png :
                Bitmap.CompressFormat.Jpeg;
            resizedImage.Compress(imageFormat, quality, stream);
            resizedImage.Recycle();

            // Reset stream and return
            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }

        #endregion
    }
}

