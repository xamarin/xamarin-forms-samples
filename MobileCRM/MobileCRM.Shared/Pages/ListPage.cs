using Xamarin.Forms;
using MobileCRM.Models;
using MobileCRM.Shared.CustomViews;
using MobileCRM.Shared.ViewModels;
using MobileCRM.Helpers;

namespace MobileCRM.Shared.Pages
{
    public class ListPageBase<T> : ContentPage where T: class, IContact, new()
    {
        public ListPageBase(MasterViewModel<T> viewModel)
        {
            BindingContext = viewModel;
        }
    }
    public class ListPage<T> : ListPageBase<T> where T: class, IContact, new()
    {
        public DataTemplate Cell { get; private set; }

        private MasterViewModel<T> ViewModel
        {
            get { return BindingContext as MasterViewModel<T>; }
        }

        public ListPage(MasterViewModel<T> viewModel) : base(viewModel)
        {
            BindingContext = viewModel;
            //Set value will directly set the value to "List"
            this.SetValue(Page.TitleProperty, "List");
            //This will bind to our BindingContext.Icon
            this.SetBinding(Page.IconProperty, "Icon");

            var list = new ListView();

            //Bind the items in our list to the observable collection of models
            list.ItemsSource = ViewModel.Models;

            Cell = new DataTemplate(typeof(ListTextCell));

            //Bind our cell's text and details properties
            Cell.SetBinding(TextCell.TextProperty, "FullName");
            Cell.SetBinding(TextCell.DetailProperty, "Industry");

            list.ItemTemplate = Cell;
            list.ItemSelected += async(sender, e) =>
            {
                if (e.SelectedItem == null)
                  return;
                viewModel.SelectedModel = e.SelectedItem as T;
                var details = new DetailEditPage<T>(viewModel);
                details.SetValue(Page.TitleProperty, e.SelectedItem.ToString());
                await Navigation.PushAsync(details);
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
