using System;
using System.IO;
using Xamarin.Forms;
using Uniforms.Misc;

namespace CoreSample
{
    using CrossMedia = Plugin.Media.CrossMedia;
    using MediaOptions = Plugin.Media.Abstractions.StoreCameraMediaOptions;

    public class Page3 : ContentPage
    {
        const double resizedImageSize = 300;

        Image takenImage;

        public Page3()
        {
            Title = "Resize";

            var getPhotoButton = new Button {
                Text = "Tap to pick a photo",
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
                //if (!CrossMedia.Current.IsCameraAvailable ||
                //    !CrossMedia.Current.IsTakePhotoSupported)
                //{
                //    await DisplayAlert("Error", "Sorry, can't connect to camera!", "OK");
                //    return;
                //}

                //var options = new MediaOptions {
                //    Directory = "Temp",
                //    Name = "photo.jpg"
                //};

                if (!CrossMedia.Current.IsPickPhotoSupported) {
                    await DisplayAlert ("Error", "Sorry, can't pick a photo!", "OK");
                    return;
                }

                var mediaFile = await CrossMedia.Current.PickPhotoAsync ();

                if (mediaFile != null)
                {
                    var layout = Content as StackLayout;

                    if (takenImage != null)
                    {
                        layout.Children.Remove(takenImage);
                    }
                        
                    var imageSource = ImageSource.FromStream(() => {
                        var origStream = mediaFile.GetStream();
                        var resizedStream = GetResizedImageStream(mediaFile.GetStream());
                        origStream.Dispose();
                        mediaFile.Dispose();
                        return resizedStream;
                    });

                    takenImage = new Image {
                        HorizontalOptions = LayoutOptions.Center,
                        Source = imageSource
                    };

                    layout.Children.Add(takenImage);
                }
            }
        }

        static Stream GetResizedImageStream(Stream imageStream)
        {
            return ImageUtils.ResizeImage(
                imageStream, resizedImageSize, resizedImageSize);
        }
    }
}


