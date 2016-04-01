using System;
using Xamarin.Forms;

namespace CoreSample
{
    using Utils = Uniforms.Core.Utils;

    public class Page2 : ContentPage
    {
        public Page2()
        {
            Title = "Images";

            const string imageName = "Graphics/balloon.jpg";
            var imageSize = Utils.GetImageSize(imageName);

            Content = new StackLayout {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                    new Label {
                        HorizontalTextAlignment = TextAlignment.Center,
                        Text = String.Format("Image: {0}", imageName)
                    },
                    new Image {
                        HorizontalOptions = LayoutOptions.Center,
                        Source = imageName
                    },
                    new Label {
                        HorizontalTextAlignment = TextAlignment.Center,
                        Text = String.Format("Size: {0} x {1}",
                            imageSize.Width, imageSize.Height)
                    },
                }
            };
        }
    }
}


