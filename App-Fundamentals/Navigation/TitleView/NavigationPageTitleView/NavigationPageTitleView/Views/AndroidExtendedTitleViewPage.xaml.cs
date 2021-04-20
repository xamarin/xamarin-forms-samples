using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace NavigationPageTitleView
{
    public partial class AndroidExtendedTitleViewPage : ContentPage
    {
        ICommand _returnToMenuPage;

        public AndroidExtendedTitleViewPage(ICommand restore)
        {
            InitializeComponent();

            _returnToMenuPage = restore;
        }

        void OnReturnButtonClicked(object sender, EventArgs e)
        {
            _returnToMenuPage.Execute(null);
        }
    }
}
