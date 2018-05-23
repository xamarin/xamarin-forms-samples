using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ButtonDemos
{
    class ToggleButton : Button
    {
        public static BindableProperty ToggledProperty =
            BindableProperty.Create("Toggled", typeof(bool), typeof(ToggleButton));

        public static BindableProperty TextColorToggledProperty =
            BindableProperty.Create("TextColorToggled", typeof(Color), typeof(ToggleButton));






    }
}
