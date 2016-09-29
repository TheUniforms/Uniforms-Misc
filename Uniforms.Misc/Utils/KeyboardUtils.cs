using System;

namespace Uniforms.Misc
{
    public interface IKeyboardEvents
    {
        /// <summary>
        /// Occurs when keyboard height changed.
        /// </summary>
        event Action<double> KeyboardHeightChanged;
    }

    /// <summary>
    /// Keyboard utils.
    /// </summary>
    public static class KeyboardUtils
    {
        public static event Action<double> KeyboardHeightChanged;

        static IKeyboardEvents implementation;

        internal static void Init (IKeyboardEvents platformImplementation)
        {
            implementation = platformImplementation;

            implementation.KeyboardHeightChanged += (double height) => {
                KeyboardHeightChanged?.Invoke (height);
            };
        }
    }
}
