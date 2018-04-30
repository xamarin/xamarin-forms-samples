using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace VsmDemos
{
    public partial class VsmAdaptiveLayoutPage : ContentPage
    {
	    public VsmAdaptiveLayoutPage ()
	    {
		    InitializeComponent ();

            SizeChanged += (sender, args) =>
            {
                string visualState = Width > Height ? "Landscape" : "Portrait";
                VisualStateManager.GoToState(mainStack, visualState);
                VisualStateManager.GoToState(menuScroll, visualState);
                VisualStateManager.GoToState(menuStack, visualState);

                foreach (View child in menuStack.Children)
                {
                    VisualStateManager.GoToState(child, visualState);
                }
            };

            SelectedCommand = new Command<string>((filename) =>
            {
                image.Source = ImageSource.FromResource("VsmDemos.Images." + filename);
            });

            menuStack.BindingContext = this;
	    }

        public ICommand SelectedCommand { private set; get; }
    }
}