using System;
using Xamarin.Forms;

namespace CoreSample
{
    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            Title = "Uniforms.Core";

            Children.Add(new Page1());
            Children.Add(new Page2());
            Children.Add(new Page3());
        }
    }
}


