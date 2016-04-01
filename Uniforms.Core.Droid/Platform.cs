using System;

namespace Uniforms.Core.Droid
{
    public static class Platform
    {
        public static void Init()
        {
            ScreenImplementation.Init();

            LocalizeImplementation.Init();

            Uniforms.Core.Plarform.Init();
        }
    }
}

