using MobileCRM.Shared.ViewModels;
using Xamarin.Forms;
using MobileCRM.Shared.CustomViews;

namespace MobileCRM.Shared.Pages
{
    public class ListPageBase<T> : ContentPage where T: class, new()
    {
        public ListPageBase(BaseViewModel<T> viewModel)
        {
            BindingContext = viewModel;
        }
    }
    public class ListPage<T> : ListPageBase<T> where T: class, new()
    {
        public DataTemplate Cell { get; private set; }

        private BaseViewModel<T> ViewModel
        {
            get { return BindingContext as BaseViewModel<T>; }
        }

        public ListPage(BaseViewModel<T> viewModel) : base(viewModel)
        {
            this.SetValue(Page.TitleProperty, "List");
            this.SetBinding(Page.IconProperty, "Icon");

            var list = new ListView();
            list.ItemsSource = ViewModel.Models;

#if __ANDROID__
            Cell = new DataTemplate(typeof(ListTextCell));
#else
            Cell = new DataTemplate(typeof(TextCell));
#endif

            
            Cell.SetBinding(TextCell.TextProperty, "FirstName");
            Cell.SetBinding(TextCell.DetailProperty, "Industry");

            list.ItemTemplate = Cell;
            list.ItemSelected += (sender, e) =>
            {
                var details = new DetailPage<T>(e.SelectedItem as T);
                Navigation.PushAsync(details);
            };
            var stack = new StackLayout();
            stack.Children.Add(list);
            Content = stack;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if(ViewModel.Models.Count == 0)
                ViewModel.LoadModelsCommand.Execute(null);
        }
    }
}
