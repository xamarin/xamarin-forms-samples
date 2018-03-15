using Xamarin.Forms;

namespace HelloXamarinFormsWorld
{
	public class App : Xamarin.Forms.Application
    {
		public App ()
        {
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
