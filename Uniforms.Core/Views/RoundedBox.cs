using System;
using Xamarin.Forms;

namespace Uniforms.Core
{
    public class RoundedBox : BoxView
    {
        /// <summary>
        /// The corner radius property.
        /// </summary>
        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create ("CornerRadius", typeof (double), typeof (RoundedBox), 0.0);

        /// <summary>
        /// The shadow radius property.
        /// </summary>
        public static readonly BindableProperty ShadowRadiusProperty =
            BindableProperty.Create ("ShadowRadius", typeof (double), typeof (RoundedBox), 0.0);

        /// <summary>
        /// Gets or sets the corner radius.
        /// </summary>
        public double CornerRadius {
            get { return (double)GetValue (CornerRadiusProperty); }
            set { SetValue (CornerRadiusProperty, value); }
        }

        /// <summary>
        /// Gets or sets the shadow radius.
        /// </summary>
        public double ShadowRadius {
            get { return (double)GetValue (ShadowRadiusProperty); }
            set { SetValue (ShadowRadiusProperty, value); }
        }

        /// <summary>
        /// Gets or sets the shadow opacity.
        /// </summary>
        public double ShadowOpacity { get; set; }

        /// <summary>
        /// Gets or sets the color of the shadow.
        /// </summary>
        public Color ShadowColor { get; set; } = Color.Black;

        /// <summary>
        /// Gets or sets the shadow offset.
        /// </summary>
        public Size ShadowOffset { get; set; } = Size.Zero;
    }
}
