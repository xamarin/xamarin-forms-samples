using CardViewDemo.Controls;
using CardViewDemo.Services;
using CardViewDemo.ViewModels;
using System.Collections.Generic;
using Xamarin.Forms;

namespace CardViewDemo
{
    public class CardViewCodePage : ContentPage
    {
        public CardViewCodePage()
        {
            Title = "CardView Code Demo";
            Padding = 10;

            StackLayout layout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill
            };

            ScrollView scroll = new ScrollView
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
                Content = layout
            };

            foreach (var person in DataService.People)
            {
                CardView card = new CardView
                {
                    BorderColor = Color.DarkGray,
                    CardTitle = person.Name,
                    CardDescription = person.Bio,
                    IconBackgroundColor = Color.SlateGray,
                    IconImageSource = ImageSource.FromFile(person.Photo)
                };
                layout.Children.Add(card);
            }

            Content = scroll;
        }
    }
}