using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace FlexLayoutDemos
{
	public partial class AdaptiveFlexLayoutPage : ContentPage
	{
		public AdaptiveFlexLayoutPage ()
		{
			InitializeComponent ();

            SizeChanged += (sender, args) =>
            {
                string state = Width > Height ? "Landscape" : "Portrait";

                VisualStateManager.GoToState(bodyFlexLayout, state);
     //           VisualStateManager.GoToState(navFlexLayout, state);

            };

            SelectedCommand = new Command<string>(
                async (string filename) => // Type pageType) =>
                {
               //     Page page = (Page)Activator.CreateInstance(pageType);
             //       await Navigation.PushAsync(page);
                }
                
                
                );

    //        navFlexLayout.BindingContext = this;
        }

        public ICommand SelectedCommand { private set; get; }
    }
}