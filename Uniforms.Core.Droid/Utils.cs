using System;

namespace Uniforms.Core.Droid
{
    public static class Utils
    {
        public static void Init()
        {
            ScreenImplementation.Init();

            LocalizeImplementation.Init();

            ImageUtilsImplementation.Init();

            Uniforms.Core.Utils.Init();
        }
    }
}

