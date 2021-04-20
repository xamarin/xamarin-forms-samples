using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace NavigationPageTitleView
{
    public partial class iOSExtendedTitleViewPage : ContentPage
    {
        ICommand _returnToMenuPage;

        public iOSExtendedTitleViewPage(ICommand restore)
        {
            InitializeComponent();

            _returnToMenuPage = restore;
            _searchBar.Effects.Add(Effect.Resolve("XamarinDocs.SearchBarEffect"));
        }

        void OnReturnButtonClicked(object sender, EventArgs e)
        {
            _returnToMenuPage.Execute(null);
        }
    }
}
