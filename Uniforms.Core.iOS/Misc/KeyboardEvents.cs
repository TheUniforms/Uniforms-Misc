using System;
using System.Diagnostics;
using UIKit;
using Foundation;
using Uniforms.Core.iOS;

[assembly: Xamarin.Forms.Dependency (typeof (KeyboardEvents))]

namespace Uniforms.Core.iOS
{
    public class KeyboardEvents : IKeyboardEvents
    {
        /// <summary>
        /// Empty method for reference.
        /// </summary>
        public static void Init ()
        {}

        /// <summary>
        /// Occurs when keyboard height changed.
        /// </summary>
        public event Action<double> KeyboardHeightChanged;

        public KeyboardEvents ()
        {
            var windowHeight = UIScreen.MainScreen.Bounds.Height;

            // Show or change frame
            NSNotificationCenter.DefaultCenter.AddObserver (
                UIKeyboard.WillChangeFrameNotification, (notify) => {
                    var info = notify.UserInfo;
                    var value = (NSValue)(info [UIKeyboard.FrameEndUserInfoKey]);
                    var height = windowHeight - value.RectangleFValue.Y;

                    Debug.WriteLine ("KeyboardEvents, height={0}", height);

                    KeyboardHeightChanged?.Invoke (height);
                });
        }
    }
}
