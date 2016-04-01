using System;
using Xamarin.Forms;

namespace Uniforms.Core
{
    public static class Screen
    {
        static IScreen screen;

        public static Size Size
        {
            get { return screen.Size; }
        }

        public static void Init()
        {
            screen = DependencyService.Get<IScreen>();
        }
    }
}

