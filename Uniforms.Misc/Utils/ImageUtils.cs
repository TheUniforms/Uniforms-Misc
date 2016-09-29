using System;
using System.IO;
using Xamarin.Forms;

namespace Uniforms.Misc
{
    public interface IImageUtils
    {
        Size GetImageSize(string name);

        Stream ResizeImage(
            Stream imageData,
            double width,
            double height,
            string format = "jpeg",
            int quality = 96);
    }

    /// <summary>
    /// Image utils.
    /// </summary>
    public static class ImageUtils
    {
        static IImageUtils implementation;

        internal static void Init (IImageUtils platformImplementation)
        {
            implementation = platformImplementation;
        }

        public static Size GetImageSize (string name)
        {
            return implementation.GetImageSize (name);
        }

        public static Stream ResizeImage (
            Stream imageData,
            double width,
            double height,
            string format = "jpeg",
            int quality = 96)
        {
            return implementation.ResizeImage (
                imageData, width, height, format, quality);
        }
    }
}

