using System;
using Xamarin.Forms;
using Uniforms.Misc;

namespace CoreSample
{
    public class Page1 : ContentPage
    {
        public Page1()
        {
            Title = "Welcome";

            var screenSize = ScreenUtils.ScreenSize;

            var fontSize = 32.0;
            var testText = "La-la-la\nHa-ha-ha!";
            var textSize = TextUtils.GetTextSize (
                testText, screenSize.Width, fontSize);

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
                        FontSize = fontSize,
                        Text = testText
                    },
                    new Label {
                        HorizontalTextAlignment = TextAlignment.Center,
                        Text = $"(text height = {textSize.Height})"
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

