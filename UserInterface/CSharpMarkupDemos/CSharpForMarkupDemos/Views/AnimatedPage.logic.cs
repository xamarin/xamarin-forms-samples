using Xamarin.Forms;
using CSharpForMarkupDemos.Helpers;

namespace CSharpForMarkupDemos.Views
{
    partial class AnimatedPage
    {
        StackLayout animatedStackLayout;

        public AnimatedPage() => Build();

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Content.IsVisible = true;
            animatedStackLayout.Children.StaggerIn(50, 0.5);
        }
    }
}
