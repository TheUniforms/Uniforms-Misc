using System;
using Xamarin.Forms;

namespace CoreSample
{
    using CrossMedia = Plugin.Media.CrossMedia;
    using MediaOptions = Plugin.Media.Abstractions.StoreCameraMediaOptions;

    public class Page3 : ContentPage
    {
        Image takenImage;

        public Page3()
        {
            Title = "Resize";

            var getPhotoButton = new Button {
                Text = "Tap to get photo",
                HorizontalOptions = LayoutOptions.Center
            };
            getPhotoButton.Clicked += GetPhotoButtonClicked;

            Content = new StackLayout {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                    getPhotoButton,
                }
            };
        }

        async void GetPhotoButtonClicked(object sender, EventArgs e)
        {
            if (await CrossMedia.Current.Initialize())
            {
                if (!CrossMedia.Current.IsCameraAvailable ||
                    !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("Error", "Sorry, can't connect to camera!", "OK");
                    return;
                }

                var options = new MediaOptions {
                    Directory = "Temp",
                    Name = "photo.jpg"
                };

                var mediaFile = await CrossMedia.Current.TakePhotoAsync(options);

                if (mediaFile != null)
                {
                    var layout = Content as StackLayout;

                    if (takenImage != null)
                    {
                        layout.Children.Remove(takenImage);
                    }
                        
                    var imageSource = ImageSource.FromStream(() => {
                        var stream = mediaFile.GetStream();
                        mediaFile.Dispose();
                        return stream;
                    });

                    takenImage = new Image {
                        HorizontalOptions = LayoutOptions.Center,
                        Source = imageSource
                    };

                    layout.Children.Add(takenImage);
                }
            }
        }
    }
}


