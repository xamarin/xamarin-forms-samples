using OfflineCurrencyConverter.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OfflineCurrencyConverter.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
    {
        private const double MinWidth = 720;

        public MainPage ()
		{
			InitializeComponent ();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            AdaptLayout();
            base.OnSizeAllocated(width, height);
        }

        protected override async void OnAppearing()
        {
            SizeChanged += MainPageSizeChanged;
            await (BindingContext as IInitializable<MainPage>).InitializeAsync();
            base.OnAppearing();
        }

        private void MainPageSizeChanged(object sender, EventArgs e)
        {
            AdaptLayout();
        }

        protected override async void OnDisappearing()
        {
            SizeChanged -= MainPageSizeChanged;
            await (BindingContext as IInitializable<MainPage>).StopAsync();
            base.OnDisappearing();
        }

        void AdaptLayout()
        {
            if(Width < MinWidth)
            {
                PreviousConversionsView.IsVisible = false;
                PreviousConversionsButton.IsVisible = true;
                Grid.SetColumnSpan(MainGrid, 2);
                Grid.SetColumn(ShareButton, 1);
            }
            else
            {
                PreviousConversionsView.IsVisible = true;
                PreviousConversionsButton.IsVisible = false;
                Grid.SetColumnSpan(MainGrid, 1);
                Grid.SetColumn(ShareButton, 2);
            }
        }
    }
}