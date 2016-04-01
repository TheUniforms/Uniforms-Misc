using System;
using Xamarin.Forms;

namespace CoreSample
{
    using Plarform = Uniforms.Core.Plarform;

    public class MainPage : ContentPage
    {
        public MainPage()
        {
            var screenSize = Plarform.ScreenSize;
            var cultureInfo = Plarform.GetCurrentCultureInfo();

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
                }
            };
        }


    }
}

