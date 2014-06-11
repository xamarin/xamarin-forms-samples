using Xamarin.Forms;
using MobileCRM.Shared.Pages;
using MobileCRM.Shared.ViewModels;
using MobileCRM.Models;

namespace MobileCRM.Shared.Pages
{
    public class MasterPage<T> : TabbedPage where T: class, IContact, new()
    {
        public MapPage<T> Map { get; private set; }
        public ListPage<T> List { get; private set; }

        public MasterPage(OptionItem menuItem)
        {
            var viewModel = new MapViewModel<T>();
            BindingContext = viewModel;

            this.SetValue(Page.TitleProperty, menuItem.Title);
            this.SetValue(Page.IconProperty, menuItem.Icon);

            Map = new MapPage<T>(viewModel);
            List = new ListPage<T>(viewModel) { Icon = "list.png" };

            this.Children.Add(Map);
            this.Children.Add(List);
        }
    }
}
