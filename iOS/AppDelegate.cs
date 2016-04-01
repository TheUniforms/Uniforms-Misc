using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace CoreSample.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            App.InitPlatform();

            var sharedApp = new App();

            LoadApplication(sharedApp);

            return base.FinishedLaunching(app, options);
        }
    }
}

