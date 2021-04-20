using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace WorkingWithTriggers
{
    public partial class MainPage : ContentPage
    {
        public ICommand NavigateCommand { get; private set; }

        public MainPage()
        {
            InitializeComponent();

            NavigateCommand = new Command<Type>(
                async (Type pageType) =>
                {
                    Page page = (Page)Activator.CreateInstance(pageType);
                    await Navigation.PushAsync(page);
                });

            BindingContext = this;
        }
    }
}
