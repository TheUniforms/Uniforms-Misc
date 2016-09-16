using System;
using System.Diagnostics;
using Xamarin.Forms;
using Uniforms.Core;

namespace CoreSample
{
    public class Page4 : ContentPage
    {
        IKeyboardEvents keyboardEvents;

        Label label;

        public Page4 ()
        {
            Title = "Keyboard";

            keyboardEvents = DependencyService.Get<IKeyboardEvents> ();
            keyboardEvents.KeyboardHeightChanged += OnKeyboardHeightChanged;

            label = new Label {
                Text = "Keyboard is hidden"
            };

            Content = new StackLayout {
                VerticalOptions = LayoutOptions.Center,

                Spacing = 10.0,
                Padding = 20.0,

                Children = {
                    new Entry {
                        Placeholder = "Enter some text...",
                    },
                    label
                },
            };
        }

        void OnKeyboardHeightChanged (double height)
        {
            Debug.WriteLine ($"OnKeyboardHeightChanged: {height}");

            label.Text = $"Keyboard height: {height}";
        }
    }
}

