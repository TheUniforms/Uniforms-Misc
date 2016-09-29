using System;
using Xamarin.Forms;

namespace CoreSample
{
    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            Title = "Uniforms.Misc";

            Children.Add (new Page1 ());
            Children.Add (new Page2 ());
            Children.Add (new Page3 ());
            Children.Add (new Page4 ());
        }
    }
}
