using System;
using Xamarin.Forms;

namespace PassingData
{
    public class SecondPageCS : ContentPage
    {
        public SecondPageCS()
        {
            var nameLabel = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                FontAttributes = FontAttributes.Bold
            };
            nameLabel.SetBinding(Label.TextProperty, "Name");

            var ageLabel = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                FontAttributes = FontAttributes.Bold
            };
            ageLabel.SetBinding(Label.TextProperty, "Age");

            var occupationLabel = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                FontAttributes = FontAttributes.Bold
            };
            occupationLabel.SetBinding(Label.TextProperty, "Occupation");

            var countryLabel = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                FontAttributes = FontAttributes.Bold
            };
            countryLabel.SetBinding(Label.TextProperty, "Country");

            var navigateButton = new Button { Text = "Previous Page" };
            navigateButton.Clicked += OnNavigateButtonClicked;

            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children = {
                    new StackLayout {
                        Orientation = StackOrientation.Horizontal,
                        Children = {
                            new Label {
                                Text = "Name:",
                                FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
                                HorizontalOptions = LayoutOptions.FillAndExpand
                            },
                            nameLabel
                        }
                    },
                    new StackLayout {
                        Orientation = StackOrientation.Horizontal,
                        Children = {
                            new Label {
                                Text = "Age:",
                                FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
                                HorizontalOptions = LayoutOptions.FillAndExpand
                            },
                            ageLabel
                        }
                    },
                    new StackLayout {
                        Orientation = StackOrientation.Horizontal,
                        Children = {
                            new Label {
                                Text = "Occupation:",
                                FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
                                HorizontalOptions = LayoutOptions.FillAndExpand
                            },
                            occupationLabel
                        }
                    },
                    new StackLayout {
                        Orientation = StackOrientation.Horizontal,
                        Children = {
                            new Label {
                                Text = "Country:",
                                FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
                                HorizontalOptions = LayoutOptions.FillAndExpand
                            },
                            countryLabel
                        }
                    },
                    navigateButton
                }
            };
        }

        async void OnNavigateButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
