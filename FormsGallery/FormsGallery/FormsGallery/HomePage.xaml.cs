using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace FormsGallery
{
    public partial class HomePage : TabbedPage
    {
        public HomePage()
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

        public ICommand NavigateCommand { private set; get; }
    }
}
