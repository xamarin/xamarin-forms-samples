using Xamarin.QuickUI;
using System.Collections.ObjectModel;
using System.Reflection.Emit;

namespace Meetum.Views
{
    public class MapDisplayPage : TabbedPage
    {
        readonly ObservableCollection<TabItem> buttons = new ObservableCollection<TabItem>();

        public MapDisplayPage()
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

        Page CreateMapTab ()
        {
            var page = new ContentPage();
            page.Content = MapFactory.InitializeMap(page);

            page.SetBinding(Page.TitleProperty, "Title");
            page.SetBinding(Page.IconProperty, "Icon");

            return page;
        }

        Page CreateListTab ()
        {
            var page = new ContentPage();
            page.Content = MapFactory.InitalizeList(page);

            //page.SetBinding(BindableObject.BindingContextProperty, "Tab2");
            page.SetBinding(Page.TitleProperty, "Title");
            page.SetBinding(Page.IconProperty, "Icon");

            return page;
        }
    }
}
