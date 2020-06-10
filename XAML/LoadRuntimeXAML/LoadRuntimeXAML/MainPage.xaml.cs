using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoadRuntimeXAML
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void OnLoadButtonClicked(object sender, EventArgs e)
        {
            string navigationButtonXAML = "<Button Text=\"Navigate\" />";
            Button navigationButton = new Button().LoadFromXaml(navigationButtonXAML);
            navigationButton.Clicked += OnNavigateButtonClicked;
            _stackLayout.Children.Add(navigationButton);
        }

        async void OnNavigateButtonClicked(object sender, EventArgs e)
        {
            // Three Labels in this XAML string have specified runtime object names (x:Name).
            // This allows their values to be set after the XAML has been loaded and parsed.
            string pageXAML = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<ContentPage xmlns=\"http://xamarin.com/schemas/2014/forms\"\nxmlns:x=\"http://schemas.microsoft.com/winfx/2009/xaml\"\nx:Class=\"LoadRuntimeXAML.CatalogItemsPage\"\nTitle=\"Catalog Items\">\n<ContentPage.Resources>\n<Style TargetType=\"Frame\">\n<Setter Property=\"BackgroundColor\" Value=\"LightYellow\" />\n<Setter Property=\"BorderColor\" Value=\"Blue\" />\n<Setter Property=\"Margin\" Value=\"10\" />\n<Setter Property=\"CornerRadius\" Value=\"15\" />\n</Style>\n\n<Style TargetType=\"Label\">\n<Setter Property=\"Margin\" Value=\"0, 4\" />\n</Style>\n\n<Style x:Key=\"headerLabel\" TargetType=\"Label\">\n<Setter Property=\"Margin\" Value=\"0, 8\" />\n<Setter Property=\"FontSize\" Value=\"Large\" />\n<Setter Property=\"TextColor\" Value=\"Blue\" />\n</Style>\n\n<Style TargetType=\"Image\">\n<Setter Property=\"FlexLayout.Order\" Value=\"-1\" />\n<Setter Property=\"FlexLayout.AlignSelf\" Value=\"Center\" />\n</Style>\n\n<Style TargetType=\"Button\">\n<Setter Property=\"Text\" Value=\"LEARN MORE\" />\n<Setter Property=\"FontSize\" Value=\"Large\" />\n<Setter Property=\"TextColor\" Value=\"White\" />\n<Setter Property=\"BackgroundColor\" Value=\"Green\" />\n<Setter Property=\"CornerRadius\" Value=\"20\" />\n</Style>\n</ContentPage.Resources>\n\n<ScrollView Orientation=\"Both\">\n<FlexLayout>\n<Frame WidthRequest=\"300\"\nHeightRequest=\"480\">\n\n<FlexLayout Direction=\"Column\">\n<Label x:Name=\"monkey1Name\"\n Style=\"{StaticResource headerLabel}\" />\n<Label Text=\"This monkey is laid back and relaxed, and likes to watch the world go by.\" />\n<Label Text=\"  &#x2022; Doesn't make a lot of noise\" />\n<Label Text=\"  &#x2022; Often smiles mysteriously\" />\n<Label Text=\"  &#x2022; Sleeps sitting up\" />\n<Image Source=\"https://upload.wikimedia.org/wikipedia/commons/thumb/4/40/Capuchin_Costa_Rica.jpg/200px-Capuchin_Costa_Rica.jpg\"\n WidthRequest=\"180\"\n HeightRequest=\"180\" />\n<Label FlexLayout.Grow=\"1\" />\n<Button />\n</FlexLayout>\n</Frame>\n\n<Frame WidthRequest=\"300\"\n  HeightRequest=\"480\">\n\n<FlexLayout Direction=\"Column\">\n<Label x:Name=\"monkey2Name\"\n Style=\"{StaticResource headerLabel}\" />\n<Label Text=\"Watch this monkey eat a giant banana.\" />\n<Label Text=\"  &#x2022; More fun than a barrel of monkeys\" />\n<Label Text=\"  &#x2022; Banana not included\" />\n<Image Source=\"https://upload.wikimedia.org/wikipedia/commons/thumb/8/83/BlueMonkey.jpg/220px-BlueMonkey.jpg\"\n WidthRequest=\"240\"\n HeightRequest=\"180\" />\n<Label FlexLayout.Grow=\"1\" />\n<Button />\n</FlexLayout>\n</Frame>\n\n<Frame WidthRequest=\"300\"\n  HeightRequest=\"480\">\n\n<FlexLayout Direction=\"Column\">\n<Label x:Name=\"monkey3Name\"\n Style=\"{StaticResource headerLabel}\" />\n<Label Text=\"This monkey reacts appropriately to ridiculous assertions and actions.\" />\n<Label Text=\"  &#x2022; Cynical but not unfriendly\" />\n<Label Text=\"  &#x2022; Seven varieties of grimaces\" />\n<Label Text=\"  &#x2022; Doesn't laugh at your jokes\" />\n<Image Source=\"https://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Papio_anubis_%28Serengeti%2C_2009%29.jpg/200px-Papio_anubis_%28Serengeti%2C_2009%29.jpg\"\n WidthRequest=\"180\"\n HeightRequest=\"180\" />\n<Label FlexLayout.Grow=\"1\" />\n<Button />\n</FlexLayout>\n</Frame>\n</FlexLayout>\n</ScrollView>\n</ContentPage>";
            ContentPage page = new ContentPage().LoadFromXaml(pageXAML);

            // Set the Text property of each Label.
            Label monkey1Label = page.FindByName<Label>("monkey1Name");
            monkey1Label.Text = "Seated Monkey";
            Label monkey2Label = page.FindByName<Label>("monkey2Name");
            monkey2Label.Text = "Banana Monkey";
            Label monkey3Label = page.FindByName<Label>("monkey3Name");
            monkey3Label.Text = "Face-Palm Monkey";

            await Navigation.PushAsync(page);
        }
    }
}
