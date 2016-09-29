using System;
using Xamarin.Forms;

namespace Uniforms.Misc
{
    public interface ITextUtils
    {
        Size GetTextSize (
            string text,
            double maxWidth,
            double fontSize = 0,
            string fontName = null);
    }

    /// <summary>
    /// Text utils.
    /// </summary>
    public static class TextUtils
    {
        static ITextUtils implementation;

        /// <summary>
        /// Init with the specified platform implementation.
        /// </summary>
        internal static void Init (ITextUtils platformImplementation)
        {
            implementation = platformImplementation;
        }

        /// <summary>
        /// Gets the size of the text.
        /// </summary>
        public static Size GetTextSize (
            string text,
            double maxWidth,
            double fontSize = 0,
            string fontName = null)
        {
            return implementation.GetTextSize (
                text, maxWidth, fontSize, fontName);
        }
    }
}
