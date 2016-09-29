using System;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

[assembly: InternalsVisibleTo ("Uniforms.Misc.iOS")]
[assembly: InternalsVisibleTo ("Uniforms.Misc.Droid")]

namespace Uniforms.Misc
{
    /// <summary>
    /// Screen utils.
    /// </summary>
    public static class ScreenUtils
    {
        public static Size ScreenSize { get; internal set; }
    }
}
