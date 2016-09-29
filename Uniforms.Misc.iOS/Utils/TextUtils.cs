using System;
using System.Drawing;
using Foundation;
using UIKit;
using Xamarin.Forms;

namespace Uniforms.Misc.iOS
{
    public class TextUtils : ITextUtils
    {
        public static void Init ()
        {
            Misc.TextUtils.Init (new TextUtils());
        }

        public Xamarin.Forms.Size GetTextSize (
            string text,
            double maxWidth,
            double fontSize = 0,
            string fontName = null)
        {
            if (fontSize <= 0) {
                fontSize = UIFont.SystemFontSize;
            }

            UIFont font = null;
            if (string.IsNullOrEmpty (fontName)) {
                font = UIFont.SystemFontOfSize ((nfloat)fontSize);
            } else {
                font = UIFont.FromName (fontName, (nfloat)fontSize);
            }

            var attributes = new UIStringAttributes { Font = font };
            var boundSize = new SizeF ((float)maxWidth, float.MaxValue);
            var options = NSStringDrawingOptions.UsesFontLeading |
                          NSStringDrawingOptions.UsesLineFragmentOrigin;

            var nsText = new NSString (text);
            var resultSize = nsText.GetBoundingRect (
                boundSize,
                options,
                attributes,
                null).Size;

            return new Xamarin.Forms.Size (
                Math.Ceiling ((double)resultSize.Width),
                Math.Ceiling ((double)resultSize.Height));
        }
    }
}
