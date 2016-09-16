using System;

namespace Uniforms.Core
{
    public interface IKeyboardEvents
    {
        /// <summary>
        /// Occurs when keyboard height changed.
        /// </summary>
        event Action<double> KeyboardHeightChanged;
    }
}
