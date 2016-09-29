using System;
using System.Diagnostics;
using UIKit;
using Foundation;
using Uniforms.Misc.iOS;

[assembly: Xamarin.Forms.Dependency (typeof (KeyboardUtils))]

namespace Uniforms.Misc.iOS
{
    public class KeyboardUtils : IKeyboardEvents
    {
        /// <summary>
        /// Empty method for reference.
        /// </summary>
        public static void Init ()
        {
            Misc.KeyboardUtils.Init (new KeyboardUtils ());
        }

        /// <summary>
        /// Occurs when keyboard height changed.
        /// </summary>
        public event Action<double> KeyboardHeightChanged;

        public KeyboardUtils ()
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
