using Xamarin.Forms;
using System.Collections.ObjectModel;
using MobileCRM.Shared.Pages;
using MobileCRM.Shared.ViewModels;
using Xamarin.Forms.Maps;

namespace MobileCRM.Shared.Pages
{
    public class MasterPage<T> : TabbedPage where T: class, new()
    {
        public MapPage<T> Map { get; private set; }
        public ListPage<T> List { get; private set; }

        public MasterPage()
        {
            var viewModel = new MapViewModel<T>();
            BindingContext = viewModel;

            Map = new MapPage<T>(viewModel);
            List = new ListPage<T>(viewModel);

            this.Children.Add(Map);
            this.Children.Add(List);
        }
    }
}
