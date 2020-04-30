using Xamarin.Forms;
using Xamarin.Forms.Markup;

namespace CSharpForMarkupDemos.Views
{
    partial class AnimatedPage : BaseContentPage
    {
        void Build()
        {
            Title = "Animated page demo";

            Content = new StackLayout
            {
                IsVisible = false,
                Children =
                {
                    new StyledLabel ("Animation example"),
                    new StyledLabel ("to illustrate"),
                    new StyledLabel ("separation"),
                    new StyledLabel ("of"),
                    new StyledLabel ("UI Markup") { TextColor = Color.Green } .Bold (),
                    new StyledLabel ("and"),
                    new StyledLabel ("UI Logic") { TextColor = Color.Red } .Bold ()
                }
            } .Assign (out animatedStackLayout);
        }

        class StyledLabel : Label
        {
            public StyledLabel(string text)
            {
                Text = text;
                this .FontSize (32)
                     .CenterHorizontal ();
            }
        }
    }
}
