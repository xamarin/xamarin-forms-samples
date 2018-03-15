using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace HelloXamarinFormsWorldXaml
{
	public class App : Application
    {
        public App()
        {
//           MainPage = new StackLayoutExample1();
//           MainPage = new StackLayoutExample2();
//           MainPage = new StackLayoutExample3();
//           MainPage = new AbsoluteLayoutExample();

            MainPage = new ContentPage
            {
                Content = new Label
                {
                    Text = "Hello, Forms !",
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                },
            };
        }
    }
}
