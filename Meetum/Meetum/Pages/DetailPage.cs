using Xamarin.QuickUI;
using System.Collections.ObjectModel;

namespace Meetum.Views
{
    public class DetailPage : TabbedPage
    {
        readonly ObservableCollection<TabItem> buttons = new ObservableCollection<TabItem>();

        public DetailPage()
        {
            BackgroundColor = Color.Black;

            buttons.Add(new TabItem { Title = "Map", Icon = "map.png" });
            buttons.Add(new TabItem { Title = "List", Icon = "list.png" });

            ItemSource = buttons;

            ItemTemplate = new DataTemplate(()=>
            {
                var page = SelectedItem == null 
                        ? CreateMapTab() 
                        : CreateListTab();

                return page;
            });
        }

        static Page CreateMapTab ()
        {
            var page = new ContentPage();
            page.Content = MapFactory.InitializeMap(page);

            page.SetBinding(BindableObject.BindingContextProperty, "MapTab");
            page.SetBinding(Page.TitleProperty, "Title");
            page.SetBinding(Page.IconProperty, "Icon");

            return page;
        }

        static Page CreateListTab ()
        {
            var page = new ContentPage();
            page.Content = MapFactory.InitalizeList(page);

            page.SetBinding(BindableObject.BindingContextProperty, "ListTab");
            page.SetBinding(Page.TitleProperty, "Title");
            page.SetBinding(Page.IconProperty, "Icon");

            return page;
        }
    }
}
