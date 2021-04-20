using Xamarin.Forms;

namespace FormsGallery.CodeExamples
{
    public class RefreshViewDemoPage : ContentPage
    {
        public RefreshViewDemoPage()
        {
            RefreshViewDemoPageViewModel viewModel = new RefreshViewDemoPageViewModel();

            // Define DataTemplate.
            DataTemplate colorItemTemplate = new DataTemplate(() =>
            {
                Grid grid = new Grid
                {
                    Margin = new Thickness(5),
                    HeightRequest = 120,
                    WidthRequest = 105
                };

                BoxView boxView = new BoxView();
                boxView.SetBinding(BoxView.ColorProperty, "Color");

                Label label = new Label
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };
                label.SetBinding(Label.TextProperty, "Name");

                grid.Children.Add(boxView);
                grid.Children.Add(label);
                return grid;
            });

            Label header = new Label
            {
                Text = "RefreshView",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            Label pullMessage = new Label
            {
                Text = "Pull the items down to refresh the ScrollView."
            };

            Label numberOfItems = new Label();
            numberOfItems.SetBinding(Label.TextProperty, "Items.Count", stringFormat: "Number of items: {0}");

            FlexLayout flexLayout = new FlexLayout
            {
                Direction = FlexDirection.Row,
                Wrap = FlexWrap.Wrap,
                AlignItems = FlexAlignItems.Center,
                AlignContent = FlexAlignContent.Center
            };
            BindableLayout.SetItemsSource(flexLayout, viewModel.Items);
            BindableLayout.SetItemTemplate(flexLayout, colorItemTemplate);

            // Set the FlexLayout as the child of the ScrollView.
            ScrollView scrollView = new ScrollView
            {
                Content = flexLayout
            };

            // Set the ScrollView as the child of the RefreshView.
            RefreshView refreshView = new RefreshView
            {
                Content = scrollView,
                RefreshColor = Color.Teal
            };
            refreshView.SetBinding(RefreshView.IsRefreshingProperty, "IsRefreshing");
            refreshView.SetBinding(RefreshView.CommandProperty, "RefreshCommand");

            // Build the page.
            Title = "RefreshView Demo";
            BindingContext = viewModel;
            Content = new StackLayout
            {
                Margin = new Thickness(10),
                Children =
                {
                    header,
                    pullMessage,
                    numberOfItems,
                    refreshView
                }
            };
        }
    }
}

