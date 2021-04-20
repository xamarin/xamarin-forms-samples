using Xamarin.Forms;

namespace Styles
{
    public class StyleClassPageCS : ContentPage
    {
        public StyleClassPageCS()
        {
            // Button styles
            var baseButtonStyle = new Style(typeof(Button))
            {
                Setters =
                {
                    new Setter
                    {
                        Property = Button.TextColorProperty,
                        Value = Color.FromHex("#FFFFFF")
                    },
                    new Setter
                    {
                        Property = Button.BorderWidthProperty,
                        Value = 0
                    }
                }
            };

            var successButtonStyle = new Style(typeof(Button))
            {
                BasedOn = baseButtonStyle,
                Class = "Success",
                Setters =
                {
                    new Setter
                    {
                        Property = VisualElement.BackgroundColorProperty,
                        Value = Color.FromHex("#449D44")
                    }
                }
            };

            var warningButtonStyle = new Style(typeof(Button))
            {
                BasedOn = baseButtonStyle,
                Class = "Warning",
                Setters =
                {
                    new Setter
                    {
                        Property = VisualElement.BackgroundColorProperty,
                        Value = Color.FromHex("#EC971F")
                    }
                }
            };

            var dangerButtonStyle = new Style(typeof(Button))
            {
                BasedOn = baseButtonStyle,
                Class = "Danger",
                Setters =
                {
                    new Setter
                    {
                        Property = VisualElement.BackgroundColorProperty,
                        Value = Color.FromHex("#C9302C")
                    }
                }
            };

            // BoxView styles
            var separatorBoxViewStyle = new Style(typeof(BoxView))
            {
                Class = "Separator",
                Setters =
                {
                    new Setter
                    {
                        Property = VisualElement.BackgroundColorProperty,
                        Value = Color.FromHex("#CCCCCC")
                    },
                    new Setter
                    {
                        Property = VisualElement.HeightRequestProperty,
                        Value = 1
                    }
                }
            };

            var roundedBoxViewStyle = new Style(typeof(BoxView))
            {
                Class = "Rounded",
                Setters =
                {
                    new Setter
                    {
                        Property = VisualElement.BackgroundColorProperty,
                        Value = Color.FromHex("#1FAECE")
                    },
                    new Setter
                    {
                        Property = View.HorizontalOptionsProperty,
                        Value = LayoutOptions.Start
                    },
                    new Setter
                    {
                        Property = BoxView.CornerRadiusProperty,
                        Value = 10
                    }
                }
            };

            var circleBoxViewStyle = new Style(typeof(BoxView))
            {
                Class = "Circle",
                Setters =
                {
                    new Setter
                    {
                        Property = VisualElement.BackgroundColorProperty,
                        Value = Color.FromHex("#1FAECE")
                    },
                    new Setter
                    {
                        Property = VisualElement.WidthRequestProperty,
                        Value = 100
                    },
                    new Setter
                    {
                        Property = VisualElement.HeightRequestProperty,
                        Value = 100
                    },
                    new Setter
                    {
                        Property = View.HorizontalOptionsProperty,
                        Value = LayoutOptions.Start
                    },
                    new Setter
                    {
                        Property = BoxView.CornerRadiusProperty,
                        Value = 50
                    }
                }
            };

            // VisualElement styles
            var rotatedVisualElementStyle = new Style(typeof(VisualElement))
            {
                Class = "Rotated",
                ApplyToDerivedTypes = true,
                Setters =
                {
                    new Setter
                    {
                        Property = VisualElement.RotationProperty,
                        Value = 45
                    }
                }
            };

            // Label styles
            var labelStyle = new Style(typeof(Label))
            {
                Setters =
                {
                    new Setter
                    {
                        Property = Label.FontSizeProperty,
                        Value = 24
                    }
                }
            };

            var bodyStyle = new Style(typeof(Label))
            {
                CanCascade = true,
                Setters =
                {
                    new Setter
                    {
                        Property = Label.TextColorProperty,
                        Value = Color.DarkGray
                    },
                    new Setter
                    {
                        Property = Label.FontAttributesProperty,
                        Value = FontAttributes.Italic
                    }
                }
            };

            Resources = new ResourceDictionary
            {
                successButtonStyle,
                warningButtonStyle,
                dangerButtonStyle,
                separatorBoxViewStyle,
                roundedBoxViewStyle,
                circleBoxViewStyle,
                rotatedVisualElementStyle,
                labelStyle
            };

            Title = "Additional style properties";
            Content = new StackLayout
            {
                Margin = new Thickness(20),
                Children =
                {
                    new Label { Text = "Style class demos", HorizontalOptions = LayoutOptions.Center, FontAttributes = FontAttributes.Bold },
                    new Label { Text = "The following controls are styled using a style class.", Style = bodyStyle },
                    new Button { Text = "Success Button", StyleClass = new [] {"Success"} },
                    new Button { Text = "Warning Button", StyleClass = new [] {"Warning"} },
                    new Button { Text = "Danger Button", StyleClass = new [] {"Danger"} },
                    new BoxView { StyleClass = new [] { "Separator" } },
                    new BoxView { Margin = new Thickness(0,20,0,0), WidthRequest = 100, HeightRequest = 100, HorizontalOptions = LayoutOptions.Center, StyleClass = new [] { "Rounded", "Rotated" } },
                    new BoxView { Margin = new Thickness(0,20,0,0), HorizontalOptions = LayoutOptions.Center, StyleClass = new [] { "Circle" } }
                }
            };
        }
    }
}

