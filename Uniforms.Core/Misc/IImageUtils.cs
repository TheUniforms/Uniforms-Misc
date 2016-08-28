using System;
using System.IO;
using Xamarin.Forms;

namespace Uniforms.Core
{
    public interface IImageUtils
    {
        Size GetImageSize(string name);

        Stream ResizeImage(Stream imageData, double width, double height,
            string format = "jpeg", int quality = 96);
    }
}

