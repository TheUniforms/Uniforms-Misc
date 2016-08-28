using System;
using Xamarin.Forms;

namespace CoreSample
{
    using Utils = Uniforms.Core.Utils;
    using RoundedBox = Uniforms.Core.RoundedBox;

    public class Page1 : ContentPage
    {
        public Page1()
        {
            Title = "Welcome";

            var screenSize = Utils.ScreenSize;
            var cultureInfo = Utils.GetCurrentCultureInfo();

            Content = new StackLayout {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                    new Label {
                        HorizontalTextAlignment = TextAlignment.Center,
                        Text = "Welcome to Xamarin Forms!"
                    },
                    new Label {
                        HorizontalTextAlignment = TextAlignment.Center,
                        Text = String.Format(
                            "Screen width = {0}\n Screen height = {1}",
                            screenSize.Width, screenSize.Height)
                    },
                    new Label {
                        HorizontalTextAlignment = TextAlignment.Center,
                        Text = String.Format("Culture info = {0}", cultureInfo)
                    },
                    new RoundedBox {
                        HorizontalOptions = LayoutOptions.Center,
                        HeightRequest = 50,
                        WidthRequest = 50,
                        BackgroundColor = Color.Purple,
                        CornerRadius = 10,

                        ShadowOffset = new Size(0, 2.0),
                        ShadowOpacity = 0.5,
                        ShadowRadius = 2.0,
                    },
                }
            };
        }
    }
}

