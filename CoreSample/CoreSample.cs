using System;
using Xamarin.Forms;
using Uniforms.Misc;

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
            Uniforms.Misc.Droid.ScreenUtils.Init ();
            Uniforms.Misc.Droid.ImageUtils.Init ();
            Uniforms.Misc.Droid.TextUtils.Init ();
            #endif

            #if __IOS__
            Xamarin.Forms.Forms.Init();
            Uniforms.Misc.iOS.ScreenUtils.Init ();
            Uniforms.Misc.iOS.ImageUtils.Init ();
            Uniforms.Misc.iOS.KeyboardUtils.Init ();
            Uniforms.Misc.iOS.TextUtils.Init ();
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

