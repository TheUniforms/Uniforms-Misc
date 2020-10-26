using System;
using Android.Widget;
using Android.Util;
using Android.Views;
using Android.Graphics;

namespace Uniforms.Misc.Droid
{
    public class TextUtils : ITextUtils
    {
        public static void Init ()
        {
            Misc.TextUtils.Init (new TextUtils ());
        }

        static Typeface textTypeface;

        static string createdFontName;

        public Xamarin.Forms.Size GetTextSize (
            string text,
            double maxWidth,
            double fontSize = 0,
            string fontName = null)
        {
            var textView = new TextView (global::Android.App.Application.Context);
            textView.Typeface = GetTypeface (fontName);
            textView.SetText (text, TextView.BufferType.Normal);
            textView.SetTextSize (ComplexUnitType.Px, (float)fontSize);

            int widthMeasureSpec = View.MeasureSpec.MakeMeasureSpec (
                (int)maxWidth, MeasureSpecMode.AtMost);

            int heightMeasureSpec = View.MeasureSpec.MakeMeasureSpec (
                0, MeasureSpecMode.Unspecified);

            textView.Measure (widthMeasureSpec, heightMeasureSpec);

            return new Xamarin.Forms.Size (
                textView.MeasuredWidth,
                textView.MeasuredHeight);
        }

        static Typeface GetTypeface (string fontName)
        {
            if (fontName == null) {
                return Typeface.Default;
            }

            if (textTypeface == null || fontName != createdFontName) {
                textTypeface = Typeface.Create (fontName, TypefaceStyle.Normal);
                createdFontName = fontName;
            }

            return textTypeface;
        }
    }
}
