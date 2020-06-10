using Xamarin.Forms;

namespace StackLayoutDemos.Views
{
    public class CombinedStackLayoutPageCS : ContentPage
    {
        public CombinedStackLayoutPageCS()
        {
            Title = "Combined StackLayouts demo";
            Content = new StackLayout
            {
                Margin = new Thickness(20),
                Children =
                {
                    new Label { Text = "Primary colors" },
                    new Frame
                    {
                        BorderColor = Color.Black,
                        Padding = new Thickness(5),
                        Content = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Spacing = 15,
                            Children =
                            {
                                new BoxView { Color = Color.Red },
                                new Label { Text = "Red", FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)), VerticalOptions = LayoutOptions.Center }
                            }
                        }
                    },
                    new Frame
                    {
                        BorderColor = Color.Black,
                        Padding = new Thickness(5),
                        Content = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Spacing = 15,
                            Children =
                            {
                                new BoxView { Color = Color.Yellow },
                                new Label { Text = "Yellow", FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)), VerticalOptions = LayoutOptions.Center }
                            }
                        }
                    },
                    new Frame
                    {
                        BorderColor = Color.Black,
                        Padding = new Thickness(5),
                        Content = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Spacing = 15,
                            Children =
                            {
                                new BoxView { Color = Color.Blue },
                                new Label { Text = "Blue", FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)), VerticalOptions = LayoutOptions.Center }
                            }
                        }
                    },
                    new Label { Text = "Secondary colors" },
                    new Frame
                    {
                        BorderColor = Color.Black,
                        Padding = new Thickness(5),
                        Content = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Spacing = 15,
                            Children =
                            {
                                new BoxView { Color = Color.Green },
                                new Label { Text = "Green", FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)), VerticalOptions = LayoutOptions.Center }
                            }
                        }
                    },
                    new Frame
                    {
                        BorderColor = Color.Black,
                        Padding = new Thickness(5),
                        Content = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Spacing = 15,
                            Children =
                            {
                                new BoxView { Color = Color.Orange },
                                new Label { Text = "Orange", FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)), VerticalOptions = LayoutOptions.Center }
                            }
                        }
                    },
                    new Frame
                    {
                        BorderColor = Color.Black,
                        Padding = new Thickness(5),
                        Content = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Spacing = 15,
                            Children =
                            {
                                new BoxView { Color = Color.Purple },
                                new Label { Text = "Purple", FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)), VerticalOptions = LayoutOptions.Center }
                            }
                        }
                    },
                }
            };
        }
    }
}
