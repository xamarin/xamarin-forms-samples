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
            //Set value will directly set the value to "List"
            this.SetValue(Page.TitleProperty, "List");
            //This will bind to our BindingContext.Icon
            this.SetBinding(Page.IconProperty, "Icon");

            var list = new ListView();

            //Bind the items in our list to the observable collection of models
            list.ItemsSource = ViewModel.Models;

            Cell = new DataTemplate(typeof(ListTextCell));

            //Bind our cell's text and details properties
            Cell.SetBinding(TextCell.TextProperty, "FirstName");
            Cell.SetBinding(TextCell.DetailProperty, "Industry");

            list.ItemTemplate = Cell;

            list.ItemSelected += (sender, e) =>
            {
                if (e.SelectedItem == null)
                  return;
                var details = new DetailPage<T>(e.SelectedItem as T);
                Navigation.PushAsync(details);
                //deselect item when pushing
                list.SelectedItem = null;
            };
            var stack = new StackLayout();
            stack.Children.Add(list);
            Content = stack;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //lazy load data when appearing, simply call the command if no data
            if(ViewModel.Models.Count == 0)
                ViewModel.LoadModelsCommand.Execute(null);
        }
    }
}
