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
            Uniforms.Core.Droid.Utils.Init();
            #endif

            #if __IOS__
            Xamarin.Forms.Forms.Init();
            Uniforms.Core.iOS.Utils.Init();
            Uniforms.Core.iOS.KeyboardEvents.Init ();
            #endif
        }

        //
        // Constructor
        //

        public CoreSample()
        {
            MainPage = new MainPage();
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

