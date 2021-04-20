using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace PlatformSpecifics
{
    public partial class ContentPageFlyoutPage : ContentPage
    {
        public static readonly BindableProperty ItemsProperty = BindableProperty.Create("Items", typeof(IList<NavigationItem>), typeof(ContentPageFlyoutPage), null);

        public IList<NavigationItem> Items
        {
            get { return (IList<NavigationItem>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        Page detailPage;

        public ContentPageFlyoutPage(ICommand restore)
        {
            InitializeComponent();

            Items = new List<NavigationItem>
            {
                new NavigationItem("Save", "\uE105", new Command(async () => await DisplayAlert("Save", "Fake save dialog", "OK"))),
                new NavigationItem("Delete", "\uE107", new Command(async () => await DisplayAlert("Delete", "Fake delete dialog", "OK"))),
                new NavigationItem("Set Detail to Navigation Page", "\uE16F", new Command(() =>
                {
                    detailPage = (Parent as FlyoutPage).Detail;
                    (Parent as FlyoutPage).Detail = new NavigationPage(new ContentPageTwo(restore));
                })),
                new NavigationItem("Set Detail to Content Page", "\uE160", new Command(() => (Parent as FlyoutPage).Detail = (detailPage == null) ? (Parent as FlyoutPage).Detail : detailPage)),
                new NavigationItem("Back", "\uE106", restore)
            };
        }

        void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            (e.Item as NavigationItem).Command.Execute(null);
        }
    }
}
