using System;
using Xamarin.Forms;

namespace CoreSample
{
    #if __ANDROID__
    using Activity = Android.App.Activity;
    using Bundle = Android.OS.Bundle;
    #endif

    public class CoreSample : Application
    {
        //
        // Private members
        //

        Label screenSizeLabel;

        //
        // Init platform
        //

        #if __ANDROID__
        public static void InitPlatform(Activity context, Bundle bundle)
        #else
        public static void InitPlatform()
        #endif
        {
            #if __ANDROID__
            Xamarin.Forms.Forms.Init(context, bundle);
            Uniforms.Core.Droid.Platform.Init();
            #endif

            #if __IOS__
            Xamarin.Forms.Forms.Init();
            Uniforms.Core.iOS.Platform.Init();
            #endif
        }

        //
        // App constructor
        //

        public CoreSample()
        {
            screenSizeLabel = new Label {
                HorizontalTextAlignment = TextAlignment.Center
            };

            MainPage = new ContentPage {                
                Content = new StackLayout {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        new Label {
                            HorizontalTextAlignment = TextAlignment.Center,
                            Text = "Welcome to Xamarin Forms!"
                        },
                        screenSizeLabel
                    }
                }
            };

            // Update content

            var screenSize = Uniforms.Core.Screen.Size;

            screenSizeLabel.Text = String.Format(
                "Screen width = {0}\n Screen height = {1}",
                screenSize.Width, screenSize.Height);
        }

        //
        // Overrides
        //

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

