using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FormsGallery.CodeExamples
{
	public class FlexLayoutDemoPage : ContentPage
	{
        class DataItem
        {
            public string Header { set; get; }

            public string Description { set; get; }

            public string Image { set; get; }

            public int ImageWidth { set; get; }

            public IList<string> Bullets { set; get; } = new List<string>();
        }

        readonly DataItem[] data =
        {
            new DataItem
            {
                Header = "Seated Monkey",
                Description = "This monkey is laid back and relaxed, and likes to watch the world go by.",
                Image = "SeatedMonkey.jpg",
                ImageWidth = 180,
                Bullets =
                {
                    "Doesn't make a lot of noise",
                    "Often smiles mysteriously",
                    "Sleeps sitting up"
                },
            },
            new DataItem
            {
                Header = "Banana Monkey",
                Description = "Watch this monkey eat a giant banana.",
                Image = "Banana.jpg",
                ImageWidth = 240,
                Bullets =
                {
                    "More fun that a barrel of monkeys",
                    "Banana not includes"
                }
            },
            new DataItem
            {
                Header = "Face-Palm Monkey",
                Description = "This monkey reacts appropriately to ridiculous assertions and actions.",
                Image = "FacePalm.jpg",
                ImageWidth = 180,
                Bullets =
                {
                    "Cynical but not unfriendly",
                    "Seven varieties of grimaces",
                    "Doesn't laugh at your jokes"
                },
            }
        };

		public FlexLayoutDemoPage ()
		{
            FlexLayout flexLayout = new FlexLayout();

            foreach (DataItem item in data)
            {
                FlexLayout itemFlexLayout = new FlexLayout
                {
                    Direction = FlexDirection.Column,
                    Children =
                    {
                        new Label
                        {
                            Text = item.Header,
                            Margin = new Thickness(0, 8),
                            FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                            TextColor = Color.Blue,
                        },
                        new Label
                        {
                            Text = item.Description,
                            Margin = new Thickness(0, 4),
                        },
                    }
                };

                foreach (string bullet in item.Bullets)
                {
                    itemFlexLayout.Children.Add(new Label
                    {
                        Text = "  \u2022 " + bullet,
                        Margin = new Thickness(0, 4)
                    }); 
                }

                var x = ImageSource.FromResource("");

                Image image = new Image
                {
                    Source = ImageSource.FromResource("FormsGallery.Images." + item.Image),
                    WidthRequest = item.ImageWidth,
                    HeightRequest = 180
                };

                FlexLayout.SetOrder(image, -1);
                FlexLayout.SetAlignSelf(image, FlexAlignSelf.Center);
                itemFlexLayout.Children.Add(image);

                Label blankLabel = new Label();
                FlexLayout.SetGrow(blankLabel, 1);
                itemFlexLayout.Children.Add(blankLabel);

                itemFlexLayout.Children.Add(new Button
                {
                    Text = "LEARN MORE",
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                    TextColor = Color.White,
                    BackgroundColor = Color.Green,
                    CornerRadius = 20
                });

                flexLayout.Children.Add(new Frame
                {
                    WidthRequest = 300,
                    HeightRequest = 480,
                    BackgroundColor = Color.LightYellow,
                    BorderColor = Color.Blue,
                    Margin = new Thickness(10),
                    CornerRadius = 15,
                    Content = itemFlexLayout
                });
            }

            // Build the page.
            Title = "FlexLayout Demo";
            Content = new ScrollView
            {
                Orientation = ScrollOrientation.Both,
                Content = flexLayout
            };
        }
	}
}