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
                string visualState = Width > Height ? "Landscape" : "Portrait";

       //         VisualStateManager.GoToState(mainFlex, visualState);
       //         VisualStateManager.GoToState(menuScroll, visualState);
         //       VisualStateManager.GoToState(menuFlex, visualState);

            //    foreach (View child in menuFlex.Children)
            //    {
            //        VisualStateManager.GoToState(child, visualState);
            //    }
            };

            SelectedCommand = new Command<string>((filename) =>
            {
      //          image.Source = ImageSource.FromResource("FlexLayoutDemos.Images." + filename);
            });

    //        menuFlex.BindingContext = this;
        }

        public ICommand SelectedCommand { private set; get; }
    }
}