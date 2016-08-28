using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Uniforms.Core;
using Uniforms.Core.iOS;

[assembly: ExportRenderer (typeof (RoundedBox), typeof (RoundedBoxRenderer))]

namespace Uniforms.Core.iOS
{
    public class RoundedBoxRenderer : BoxRenderer
    {
        protected override void OnElementChanged (ElementChangedEventArgs<BoxView> e)
        {
            base.OnElementChanged (e);

            if (Element != null) {
                Layer.MasksToBounds = true;
                UpdateCornerRadius (Element as RoundedBox);
            }
        }

        protected override void OnElementPropertyChanged (object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged (sender, e);

            if (e.PropertyName == RoundedBox.CornerRadiusProperty.PropertyName) {
                UpdateCornerRadius (Element as RoundedBox);
            }
        }

        void UpdateCornerRadius (RoundedBox box)
        {
            Layer.CornerRadius = (float)box.CornerRadius;
        }
    }
}