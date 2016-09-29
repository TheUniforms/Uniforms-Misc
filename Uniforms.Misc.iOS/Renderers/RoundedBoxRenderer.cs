using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Uniforms.Misc;
using Uniforms.Misc.iOS;
using CoreGraphics;
using CoreAnimation;
using UIKit;

[assembly: ExportRenderer (typeof (RoundedBox), typeof (RoundedBoxRenderer))]

namespace Uniforms.Misc.iOS
{
    public class RoundedBoxRenderer : BoxRenderer
    {
        /// <summary>
        /// The color layer.
        /// </summary>
        CALayer colorLayer = new CALayer { MasksToBounds = true };

        protected override void OnElementChanged (ElementChangedEventArgs<BoxView> e)
        {
            base.OnElementChanged (e);

            if (Element != null) {
                Layer.MasksToBounds = false;
                Layer.BackgroundColor = Color.Transparent.ToCGColor ();
                Layer.AddSublayer (colorLayer);
                UpdateLayers ();
                UpdateColor ();
            }
        }

        protected override void OnElementPropertyChanged (object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged (sender, e);

            if (e.PropertyName == RoundedBox.CornerRadiusProperty.PropertyName || 
                e.PropertyName == RoundedBox.ShadowRadiusProperty.PropertyName) {
                UpdateLayers ();
            } else if (e.PropertyName == VisualElement.BackgroundColorProperty.PropertyName) {
                UpdateColor ();
            }
        }

        void UpdateColor ()
        {
            colorLayer.BackgroundColor = Element.BackgroundColor.ToCGColor ();
        }

        void UpdateLayers ()
        {
            var box = Element as RoundedBox;

            colorLayer.CornerRadius = (float)box.CornerRadius;

            if (box.ShadowRadius > 0) {
                Layer.ShadowRadius = (float)box.ShadowRadius;
                Layer.ShadowOpacity = (float)box.ShadowOpacity;
                Layer.ShadowColor = box.ShadowColor.ToCGColor ();
                Layer.ShadowOffset = box.ShadowOffset.ToSizeF ();
            } else {
                Layer.ShadowOpacity = 0;
            }
        }

        public override void LayoutSubviews ()
        {
            base.LayoutSubviews ();

            colorLayer.Frame = Layer.Bounds;

            var box = Element as RoundedBox;
            if (Layer.ShadowOpacity > 0) {
                Layer.ShadowPath = UIBezierPath.FromRoundedRect (
                    Layer.Bounds, (float)box.CornerRadius).CGPath;
            }
        }

        public override void Draw (CGRect rect)
        {
        }
    }
}